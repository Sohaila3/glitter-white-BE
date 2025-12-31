using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IEmployeeService
{
    Task<PagedResponse<EmployeeDto>> GetEmployeesAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<EmployeeDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<EmployeeDto>> CreateAsync(EmployeeDto dto);
    Task<ApiResponse<EmployeeDto>> UpdateAsync(int id, EmployeeDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
