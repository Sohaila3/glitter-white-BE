using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using ServiceEntity = gLiter.Core.Models.Service;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public ServiceService(IServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<ServiceDto>> GetServicesAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<ServiceDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<ServiceDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<ServiceDto>.Fail("Service not found");
        }

        return ApiResponse<ServiceDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<ServiceDto>> CreateAsync(ServiceDto dto)
    {
        var entity = _mapper.Map<ServiceEntity>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<ServiceDto>.Ok(MapToDto(created, "en"), "Service created");
    }

    public async Task<ApiResponse<ServiceDto>> UpdateAsync(int id, ServiceDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<ServiceDto>.Fail("Service not found");
        }

        entity.TitleAr = dto.TitleAr;
        entity.TitleEn = dto.TitleEn;
        entity.DescriptionAr = dto.DescriptionAr;
        entity.DescriptionEn = dto.DescriptionEn;
        entity.IconUrl = dto.IconUrl;
        await _repository.UpdateAsync(entity);

        return ApiResponse<ServiceDto>.Ok(MapToDto(entity, "en"), "Service updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Service deleted");
    }

    private ServiceDto MapToDto(ServiceEntity entity, string lang)
    {
        var dto = _mapper.Map<ServiceDto>(entity);
        dto.Title = GetLocalized(entity.TitleAr, entity.TitleEn, lang);
        dto.Description = GetLocalized(entity.DescriptionAr, entity.DescriptionEn, lang);
        return dto;
    }

    private static string GetLocalized(string ar, string en, string lang) => string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? ar : en;
}
