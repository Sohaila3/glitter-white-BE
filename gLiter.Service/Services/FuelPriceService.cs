using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class FuelPriceService : IFuelPriceService
{
    private readonly IFuelPriceRepository _repository;
    private readonly IMapper _mapper;

    public FuelPriceService(IFuelPriceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<FuelPriceDto>> GetFuelPricesAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<FuelPriceDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<FuelPriceDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<FuelPriceDto>.Fail("Fuel price not found");
        }

        return ApiResponse<FuelPriceDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<FuelPriceDto>> CreateAsync(FuelPriceDto dto)
    {
        var entity = _mapper.Map<FuelPrice>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<FuelPriceDto>.Ok(MapToDto(created, "en"), "Fuel price created");
    }

    public async Task<ApiResponse<FuelPriceDto>> UpdateAsync(int id, FuelPriceDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<FuelPriceDto>.Fail("Fuel price not found");
        }

        entity.TitleAr = dto.TitleAr;
        entity.TitleEn = dto.TitleEn;
        entity.DescriptionAr = dto.DescriptionAr;
        entity.DescriptionEn = dto.DescriptionEn;
        entity.FuelType = dto.FuelType;
        entity.Price = dto.Price;
        entity.EffectiveDate = dto.EffectiveDate;
        await _repository.UpdateAsync(entity);

        return ApiResponse<FuelPriceDto>.Ok(MapToDto(entity, "en"), "Fuel price updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Fuel price deleted");
    }

    private FuelPriceDto MapToDto(FuelPrice entity, string lang)
    {
        var dto = _mapper.Map<FuelPriceDto>(entity);
        dto.Title = GetLocalized(entity.TitleAr, entity.TitleEn, lang);
        dto.Description = GetLocalized(entity.DescriptionAr, entity.DescriptionEn, lang);
        return dto;
    }

    private static string GetLocalized(string ar, string en, string lang) => string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? ar : en;
}
