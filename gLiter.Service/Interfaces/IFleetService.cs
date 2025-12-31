using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IFleetService
{
    Task<PagedResponse<FleetDto>> GetFleetAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<FleetDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<FleetDto>> CreateAsync(FleetDto dto);
    Task<ApiResponse<FleetDto>> UpdateAsync(int id, FleetDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
