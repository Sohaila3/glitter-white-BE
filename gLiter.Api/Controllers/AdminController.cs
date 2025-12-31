using System.Security.Claims;
using gLiter.Core.Constants;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace gLiter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = AdminRoles.SuperAdmin)]
public class AdminController : ControllerBase
{
    private readonly IAuthService _authService;

    public AdminController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [SwaggerOperation(Summary = "Register a new admin", Description = "Only Admin/SuperAdmin can create other admins. Prevents creating higher roles." )]
    public async Task<IActionResult> Register([FromBody] AdminRegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var requesterId = GetCurrentAdminId();
        if (requesterId == 0)
        {
            return Unauthorized(ApiResponse<string>.Fail("Invalid token"));
        }

        var result = await _authService.RegisterAdminAsync(dto, requesterId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("all")]
    [SwaggerOperation(Summary = "List all admins", Description = "Returns all admins with status and roles.")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _authService.GetAllAdminsAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get admin by id")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _authService.GetAdminByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPut("activate/{id:int}")]
    [SwaggerOperation(Summary = "Activate admin")]
    public async Task<IActionResult> Activate(int id)
    {
        var requesterId = GetCurrentAdminId();
        if (requesterId == 0)
        {
            return Unauthorized(ApiResponse<string>.Fail("Invalid token"));
        }

        var result = await _authService.ActivateAdminAsync(id, requesterId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("deactivate/{id:int}")]
    [SwaggerOperation(Summary = "Deactivate admin", Description = "Admins cannot deactivate themselves. SuperAdmin cannot be deactivated.")]
    public async Task<IActionResult> Deactivate(int id)
    {
        var requesterId = GetCurrentAdminId();
        if (requesterId == 0)
        {
            return Unauthorized(ApiResponse<string>.Fail("Invalid token"));
        }

        var result = await _authService.DeactivateAdminAsync(id, requesterId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete admin", Description = "Only SuperAdmin can delete admins. SuperAdmin cannot be deleted.")]
    public async Task<IActionResult> Delete(int id)
    {
        var requesterId = GetCurrentAdminId();
        if (requesterId == 0)
        {
            return Unauthorized(ApiResponse<string>.Fail("Invalid token"));
        }

        var result = await _authService.DeleteAdminAsync(id, requesterId);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    private int GetCurrentAdminId()
    {
        var idClaim = User.FindFirstValue("admin_id")
                      ?? User.FindFirstValue(ClaimTypes.NameIdentifier)
                      ?? User.FindFirst("nameid")?.Value
                      ?? User.FindFirst(c => c.Type.Contains("nameidentifier", StringComparison.OrdinalIgnoreCase))?.Value
                      ?? User.FindFirstValue(ClaimTypes.Name);
        return int.TryParse(idClaim, out var id) ? id : 0;
    }
}
