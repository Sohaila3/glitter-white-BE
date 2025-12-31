using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IStationService
{
    Task<PagedResponse<StationDto>> GetStationsAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<StationDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<StationDto>> CreateAsync(StationDto dto);
    Task<ApiResponse<StationDto>> UpdateAsync(int id, StationDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
