using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IFuelPriceService
{
    Task<PagedResponse<FuelPriceDto>> GetFuelPricesAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<FuelPriceDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<FuelPriceDto>> CreateAsync(FuelPriceDto dto);
    Task<ApiResponse<FuelPriceDto>> UpdateAsync(int id, FuelPriceDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
