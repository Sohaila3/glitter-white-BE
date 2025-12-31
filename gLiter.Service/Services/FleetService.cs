using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class FleetService : IFleetService
{
    private readonly IFleetRepository _repository;
    private readonly IMapper _mapper;

    public FleetService(IFleetRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<FleetDto>> GetFleetAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<FleetDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<FleetDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return ApiResponse<FleetDto>.Fail("Fleet item not found");
        return ApiResponse<FleetDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<FleetDto>> CreateAsync(FleetDto dto)
    {
        var entity = _mapper.Map<FleetVehicle>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<FleetDto>.Ok(MapToDto(created, "en"), "Fleet item created");
    }

    public async Task<ApiResponse<FleetDto>> UpdateAsync(int id, FleetDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return ApiResponse<FleetDto>.Fail("Fleet item not found");

        entity.TitleAr = dto.NameAr;
        entity.TitleEn = dto.NameEn;
        entity.LogoUrl = dto.LogoUrl;
        await _repository.UpdateAsync(entity);

        return ApiResponse<FleetDto>.Ok(MapToDto(entity, "en"), "Fleet item updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Fleet item deleted");
    }

    private FleetDto MapToDto(FleetVehicle e, string lang)
    {
        var dto = _mapper.Map<FleetDto>(e);
        dto.Name = string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? e.TitleAr : e.TitleEn;
        return dto;
    }
}
