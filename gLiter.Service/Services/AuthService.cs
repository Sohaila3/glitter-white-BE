using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Constants;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace gLiter.Service.Services;

public class AuthService : IAuthService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthService(IAdminRepository adminRepository, IConfiguration configuration, IMapper mapper)
    {
        _adminRepository = adminRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<ApiResponse<string>> LoginAsync(AdminLoginDto dto)
    {
        var admin = await _adminRepository.GetByEmailOrUsernameAsync(dto.EmailOrUsername);
        if (admin == null || !VerifyPassword(dto.Password, admin.PasswordHash, admin.PasswordSalt))
        {
            return ApiResponse<string>.Fail("Invalid credentials");
        }

        if (!admin.IsActive)
        {
            return ApiResponse<string>.Fail("Account is inactive");
        }

        var token = GenerateJwt(admin);
        return ApiResponse<string>.Ok(token, "Login successful");
    }

    public async Task<ApiResponse<AdminResponseDto>> RegisterAdminAsync(AdminRegisterDto dto, int createdById)
    {
        var creator = await _adminRepository.GetByIdAsync(createdById);
        if (creator == null || !creator.IsActive)
        {
            return ApiResponse<AdminResponseDto>.Fail("Not authorized");
        }

        var normalizedRole = NormalizeRole(dto.Role);
        if (!IsSuperAdmin(creator) && normalizedRole == AdminRoles.SuperAdmin)
        {
            return ApiResponse<AdminResponseDto>.Fail("Cannot create higher role");
        }

        if (await _adminRepository.GetByEmailAsync(dto.Email) != null)
        {
            return ApiResponse<AdminResponseDto>.Fail("Email already exists");
        }

        if (await _adminRepository.GetByUsernameAsync(dto.Username) != null)
        {
            return ApiResponse<AdminResponseDto>.Fail("Username already exists");
        }

        var adminUser = _mapper.Map<AdminUser>(dto);
        adminUser.Role = normalizedRole;
        adminUser.IsActive = true;
        // record who created this admin
        adminUser.CreatedById = createdById;
        adminUser.CreatedByName = creator.Username;
        var (hash, salt) = CreatePasswordHash(dto.Password);
        adminUser.PasswordHash = hash;
        adminUser.PasswordSalt = salt;

        await _adminRepository.AddAsync(adminUser);
        var response = _mapper.Map<AdminResponseDto>(adminUser);
        return ApiResponse<AdminResponseDto>.Ok(response, "Admin created");
    }

    public async Task<ApiResponse<IEnumerable<AdminResponseDto>>> GetAllAdminsAsync()
    {
        var admins = await _adminRepository.GetAllAdminsAsync();
        var mapped = admins.Select(_mapper.Map<AdminResponseDto>).ToList();
        return ApiResponse<IEnumerable<AdminResponseDto>>.Ok(mapped);
    }

    public async Task<ApiResponse<AdminResponseDto>> GetAdminByIdAsync(int id)
    {
        var admin = await _adminRepository.GetByIdAsync(id);
        if (admin == null)
        {
            return ApiResponse<AdminResponseDto>.Fail("Admin not found");
        }

        var mapped = _mapper.Map<AdminResponseDto>(admin);
        return ApiResponse<AdminResponseDto>.Ok(mapped);
    }

    public async Task<ApiResponse<bool>> DeactivateAdminAsync(int adminId, int actedById)
    {
        if (adminId == actedById)
        {
            return ApiResponse<bool>.Fail("Admin cannot deactivate themselves");
        }

        var actor = await _adminRepository.GetByIdAsync(actedById);
        if (actor == null || !actor.IsActive)
        {
            return ApiResponse<bool>.Fail("Not authorized");
        }

        var target = await _adminRepository.GetByIdAsync(adminId);
        if (target == null)
        {
            return ApiResponse<bool>.Fail("Admin not found");
        }

        if (target.IsPrimary)
        {
            return ApiResponse<bool>.Fail("Primary admin cannot be deactivated");
        }

        if (IsSuperAdmin(target))
        {
            return ApiResponse<bool>.Fail("SuperAdmin cannot be deactivated");
        }

        if (!IsSuperAdmin(actor) && IsHigherRole(target, actor))
        {
            return ApiResponse<bool>.Fail("Cannot deactivate higher role");
        }

        if (!target.IsActive)
        {
            return ApiResponse<bool>.Ok(true, "Admin already inactive");
        }

        target.IsActive = false;
        await _adminRepository.UpdateAsync(target);
        return ApiResponse<bool>.Ok(true, "Admin deactivated");
    }

    public async Task<ApiResponse<bool>> ActivateAdminAsync(int adminId, int actedById)
    {
        var actor = await _adminRepository.GetByIdAsync(actedById);
        if (actor == null || !actor.IsActive)
        {
            return ApiResponse<bool>.Fail("Not authorized");
        }

        var target = await _adminRepository.GetByIdAsync(adminId);
        if (target == null)
        {
            return ApiResponse<bool>.Fail("Admin not found");
        }

        if (!IsSuperAdmin(actor) && IsHigherRole(target, actor))
        {
            return ApiResponse<bool>.Fail("Cannot activate higher role");
        }

        if (target.IsActive)
        {
            return ApiResponse<bool>.Ok(true, "Admin already active");
        }

        target.IsActive = true;
        await _adminRepository.UpdateAsync(target);
        return ApiResponse<bool>.Ok(true, "Admin activated");
    }

    public async Task<ApiResponse<bool>> DeleteAdminAsync(int adminId, int actedById)
    {
        if (adminId == actedById)
        {
            return ApiResponse<bool>.Fail("Admin cannot delete themselves");
        }

        var actor = await _adminRepository.GetByIdAsync(actedById);
        if (actor == null || !actor.IsActive)
        {
            return ApiResponse<bool>.Fail("Not authorized");
        }

        if (!IsSuperAdmin(actor))
        {
            return ApiResponse<bool>.Fail("Only SuperAdmin can delete admins");
        }

        var target = await _adminRepository.GetByIdAsync(adminId);
        if (target == null)
        {
            return ApiResponse<bool>.Fail("Admin not found");
        }

        if (target.IsPrimary)
        {
            return ApiResponse<bool>.Fail("Primary admin cannot be deleted");
        }

        if (IsSuperAdmin(target))
        {
            return ApiResponse<bool>.Fail("SuperAdmin cannot be deleted");
        }

        await _adminRepository.DeleteAsync(adminId);
        return ApiResponse<bool>.Ok(true, "Admin deleted");
    }

    private string GenerateJwt(AdminUser admin)
    {
        var key = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key missing");
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var expiresMinutes = int.TryParse(_configuration["Jwt:ExpiresMinutes"], out var minutes) ? minutes : 60;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, admin.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("admin_id", admin.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
            new Claim(ClaimTypes.Name, admin.Username),
            new Claim(ClaimTypes.Role, admin.Role)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
    }

    private static (byte[] hash, byte[] salt) CreatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        var salt = hmac.Key;
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return (hash, salt);
    }

    private static string NormalizeRole(string role)
    {
        if (string.Equals(role, AdminRoles.SuperAdmin, StringComparison.OrdinalIgnoreCase)) return AdminRoles.SuperAdmin;
        if (string.Equals(role, AdminRoles.CustomerService, StringComparison.OrdinalIgnoreCase)) return AdminRoles.CustomerService;
        if (string.Equals(role, AdminRoles.HR, StringComparison.OrdinalIgnoreCase)) return AdminRoles.HR;
        return AdminRoles.CustomerService; // Default role
    }

    private static bool IsSuperAdmin(AdminUser admin) => string.Equals(admin.Role, AdminRoles.SuperAdmin, StringComparison.OrdinalIgnoreCase);

    private static bool IsHigherRole(AdminUser target, AdminUser actor)
    {
        if (IsSuperAdmin(target) && !IsSuperAdmin(actor))
        {
            return true;
        }

        return false;
    }
}
