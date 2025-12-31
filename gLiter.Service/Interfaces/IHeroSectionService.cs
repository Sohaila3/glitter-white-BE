using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IHeroSectionService
{
    Task<PagedResponse<HeroSectionDto>> GetHeroSectionsAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<HeroSectionDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<HeroSectionDto>> CreateAsync(HeroSectionDto dto);
    Task<ApiResponse<HeroSectionDto>> UpdateAsync(int id, HeroSectionDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
