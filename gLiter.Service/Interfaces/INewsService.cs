using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface INewsService
{
    Task<PagedResponse<NewsDto>> GetNewsAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<NewsDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<NewsDto>> CreateAsync(NewsDto dto);
    Task<ApiResponse<NewsDto>> UpdateAsync(int id, NewsDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
