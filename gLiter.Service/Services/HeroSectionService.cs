using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class HeroSectionService : IHeroSectionService
{
    private readonly IHeroSectionRepository _repository;
    private readonly IMapper _mapper;

    public HeroSectionService(IHeroSectionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<HeroSectionDto>> GetHeroSectionsAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<HeroSectionDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<HeroSectionDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<HeroSectionDto>.Fail("Hero Section not found");
        }

        return ApiResponse<HeroSectionDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<HeroSectionDto>> CreateAsync(HeroSectionDto dto)
    {
        var entity = _mapper.Map<HeroSection>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<HeroSectionDto>.Ok(MapToDto(created, "en"), "Hero Section created");
    }

    public async Task<ApiResponse<HeroSectionDto>> UpdateAsync(int id, HeroSectionDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<HeroSectionDto>.Fail("Hero Section not found");
        }

        entity.TitleAr = dto.TitleAr;
        entity.TitleEn = dto.TitleEn;
        entity.DescriptionAr = dto.DescriptionAr;
        entity.DescriptionEn = dto.DescriptionEn;
        entity.ImageUrl = dto.ImageUrl;
        await _repository.UpdateAsync(entity);

        return ApiResponse<HeroSectionDto>.Ok(MapToDto(entity, "en"), "Hero Section updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Hero Section deleted");
    }

    private HeroSectionDto MapToDto(HeroSection entity, string lang)
    {
        var dto = _mapper.Map<HeroSectionDto>(entity);
        dto.Title = GetLocalized(entity.TitleAr, entity.TitleEn, lang);
        dto.Description = GetLocalized(entity.DescriptionAr, entity.DescriptionEn, lang);
        return dto;
    }

    private static string GetLocalized(string ar, string en, string lang) => string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? ar : en;
}
