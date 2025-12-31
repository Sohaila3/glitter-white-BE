using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IGalleryService
{
    Task<PagedResponse<GalleryDto>> GetGalleryAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<GalleryDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<GalleryDto>> CreateAsync(GalleryDto dto);
    Task<ApiResponse<GalleryDto>> UpdateAsync(int id, GalleryDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
