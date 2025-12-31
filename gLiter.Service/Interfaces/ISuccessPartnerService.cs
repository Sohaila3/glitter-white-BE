using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface ISuccessPartnerService
{
    Task<PagedResponse<SuccessPartnerDto>> GetPartnersAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<SuccessPartnerDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<SuccessPartnerDto>> CreateAsync(SuccessPartnerDto dto);
    Task<ApiResponse<SuccessPartnerDto>> UpdateAsync(int id, SuccessPartnerDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
