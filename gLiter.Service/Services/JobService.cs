using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _repository;
    private readonly IMapper _mapper;

    public JobService(IJobRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<JobDto>> GetJobsAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<JobDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<JobDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<JobDto>.Fail("Job not found");
        }

        return ApiResponse<JobDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<JobDto>> CreateAsync(JobDto dto)
    {
        var entity = _mapper.Map<Job>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<JobDto>.Ok(MapToDto(created, "en"), "Job created");
    }

    public async Task<ApiResponse<JobDto>> UpdateAsync(int id, JobDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<JobDto>.Fail("Job not found");
        }

        entity.TitleAr = dto.TitleAr;
        entity.TitleEn = dto.TitleEn;
        entity.DescriptionAr = dto.DescriptionAr;
        entity.DescriptionEn = dto.DescriptionEn;
        entity.Location = dto.Location;
        entity.IsActive = dto.IsActive;
        entity.PostedAt = dto.PostedAt;
        entity.ExpiresAt = dto.ExpiresAt;
        await _repository.UpdateAsync(entity);

        return ApiResponse<JobDto>.Ok(MapToDto(entity, "en"), "Job updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Job deleted");
    }

    private JobDto MapToDto(Job entity, string lang)
    {
        var dto = _mapper.Map<JobDto>(entity);
        dto.Title = GetLocalized(entity.TitleAr, entity.TitleEn, lang);
        dto.Description = GetLocalized(entity.DescriptionAr, entity.DescriptionEn, lang);
        return dto;
    }

    private static string GetLocalized(string ar, string en, string lang) => string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? ar : en;
}
