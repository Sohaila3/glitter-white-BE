using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<EmployeeDto>> GetEmployeesAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<EmployeeDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<EmployeeDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return ApiResponse<EmployeeDto>.Fail("Employee not found");
        return ApiResponse<EmployeeDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<EmployeeDto>> CreateAsync(EmployeeDto dto)
    {
        var entity = new Employee
        {
            TitleAr = dto.NameAr,
            TitleEn = dto.NameEn,
            PositionAr = dto.PositionAr,
            Position = dto.PositionEn,
            ImageUrl = dto.ImageUrl,
            Email = dto.Email,
            Phone = dto.Phone,
            IsActive = dto.IsActive,
            DisplayOrder = dto.DisplayOrder
        };
        var created = await _repository.AddAsync(entity);
        return ApiResponse<EmployeeDto>.Ok(MapToDto(created, "en"), "Employee created");
    }

    public async Task<ApiResponse<EmployeeDto>> UpdateAsync(int id, EmployeeDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return ApiResponse<EmployeeDto>.Fail("Employee not found");

        entity.TitleAr = dto.NameAr;
        entity.TitleEn = dto.NameEn;
        entity.PositionAr = dto.PositionAr;
        entity.Position = dto.PositionEn;
        entity.ImageUrl = dto.ImageUrl;
        entity.Email = dto.Email;
        entity.Phone = dto.Phone;
        entity.IsActive = dto.IsActive;
        entity.DisplayOrder = dto.DisplayOrder;

        await _repository.UpdateAsync(entity);
        return ApiResponse<EmployeeDto>.Ok(MapToDto(entity, "en"), "Employee updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Employee deleted");
    }

    private EmployeeDto MapToDto(Employee e, string lang)
    {
        var isAr = string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase);
        return new EmployeeDto
        {
            Id = e.Id,
            NameAr = e.TitleAr,
            NameEn = e.TitleEn,
            Name = isAr ? e.TitleAr : e.TitleEn,
            PositionAr = e.PositionAr,
            PositionEn = e.Position,
            Position = isAr ? e.PositionAr : e.Position,
            ImageUrl = e.ImageUrl,
            Email = e.Email,
            Phone = e.Phone,
            IsActive = e.IsActive,
            DisplayOrder = e.DisplayOrder,
            CreatedAt = e.CreatedAt
        };
    }
}
