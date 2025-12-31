using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class StationService : IStationService
{
    private readonly IStationRepository _repository;
    private readonly IMapper _mapper;

    public StationService(IStationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<StationDto>> GetStationsAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<StationDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<StationDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<StationDto>.Fail("Station not found");
        }

        return ApiResponse<StationDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<StationDto>> CreateAsync(StationDto dto)
    {
        var entity = _mapper.Map<Station>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<StationDto>.Ok(MapToDto(created, "en"), "Station created");
    }

    public async Task<ApiResponse<StationDto>> UpdateAsync(int id, StationDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<StationDto>.Fail("Station not found");
        }

        entity.TitleAr = dto.TitleAr;
        entity.TitleEn = dto.TitleEn;
        entity.DescriptionAr = dto.DescriptionAr;
        entity.DescriptionEn = dto.DescriptionEn;
        entity.Address = dto.Address;
        entity.City = dto.City;
        entity.Country = dto.Country;
        entity.Phone = dto.Phone;
        entity.Latitude = dto.Latitude;
        entity.Longitude = dto.Longitude;
        await _repository.UpdateAsync(entity);

        return ApiResponse<StationDto>.Ok(MapToDto(entity, "en"), "Station updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Station deleted");
    }

    private StationDto MapToDto(Station entity, string lang)
    {
        var dto = _mapper.Map<StationDto>(entity);
        dto.Title = GetLocalized(entity.TitleAr, entity.TitleEn, lang);
        dto.Description = GetLocalized(entity.DescriptionAr, entity.DescriptionEn, lang);
        return dto;
    }

    private static string GetLocalized(string ar, string en, string lang) => string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? ar : en;
}
