using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IServiceService
{
    Task<PagedResponse<ServiceDto>> GetServicesAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<ServiceDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<ServiceDto>> CreateAsync(ServiceDto dto);
    Task<ApiResponse<ServiceDto>> UpdateAsync(int id, ServiceDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
