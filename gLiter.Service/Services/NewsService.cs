using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _repository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<NewsDto>> GetNewsAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<NewsDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<NewsDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<NewsDto>.Fail("News not found");
        }

        return ApiResponse<NewsDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<NewsDto>> CreateAsync(NewsDto dto)
    {
        var entity = _mapper.Map<News>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<NewsDto>.Ok(MapToDto(created, "en"), "News created");
    }

    public async Task<ApiResponse<NewsDto>> UpdateAsync(int id, NewsDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<NewsDto>.Fail("News not found");
        }

        entity.TitleAr = dto.TitleAr;
        entity.TitleEn = dto.TitleEn;
        entity.DescriptionAr = dto.DescriptionAr;
        entity.DescriptionEn = dto.DescriptionEn;
        entity.ImageUrl = dto.ImageUrl;
        entity.PublishedAt = dto.PublishedAt;
        entity.IsPublished = dto.IsPublished;
        await _repository.UpdateAsync(entity);

        return ApiResponse<NewsDto>.Ok(MapToDto(entity, "en"), "News updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "News deleted");
    }

    private NewsDto MapToDto(News entity, string lang)
    {
        var dto = _mapper.Map<NewsDto>(entity);
        dto.Title = GetLocalized(entity.TitleAr, entity.TitleEn, lang);
        dto.Description = GetLocalized(entity.DescriptionAr, entity.DescriptionEn, lang);
        return dto;
    }

    private static string GetLocalized(string ar, string en, string lang) => string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? ar : en;
}
