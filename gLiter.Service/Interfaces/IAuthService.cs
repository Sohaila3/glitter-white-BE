using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<string>> LoginAsync(AdminLoginDto dto);
    Task<ApiResponse<AdminResponseDto>> RegisterAdminAsync(AdminRegisterDto dto, int createdById);
    Task<ApiResponse<IEnumerable<AdminResponseDto>>> GetAllAdminsAsync();
    Task<ApiResponse<AdminResponseDto>> GetAdminByIdAsync(int id);
    Task<ApiResponse<bool>> DeactivateAdminAsync(int adminId, int actedById);
    Task<ApiResponse<bool>> ActivateAdminAsync(int adminId, int actedById);
    Task<ApiResponse<bool>> DeleteAdminAsync(int adminId, int actedById);
}
