using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class SuccessPartnerService : ISuccessPartnerService
{
    private readonly ISuccessPartnerRepository _repository;
    private readonly IMapper _mapper;

    public SuccessPartnerService(ISuccessPartnerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<SuccessPartnerDto>> GetPartnersAsync(string lang, int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e, lang)).ToList();
        return PagedResponse<SuccessPartnerDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<SuccessPartnerDto>> GetByIdAsync(int id, string lang)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<SuccessPartnerDto>.Fail("Partner not found");
        }

        return ApiResponse<SuccessPartnerDto>.Ok(MapToDto(entity, lang));
    }

    public async Task<ApiResponse<SuccessPartnerDto>> CreateAsync(SuccessPartnerDto dto)
    {
        var entity = _mapper.Map<SuccessPartner>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<SuccessPartnerDto>.Ok(MapToDto(created, "en"), "Partner created");
    }

    public async Task<ApiResponse<SuccessPartnerDto>> UpdateAsync(int id, SuccessPartnerDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<SuccessPartnerDto>.Fail("Partner not found");
        }

        entity.TitleAr = dto.NameAr;
        entity.TitleEn = dto.NameEn;
        entity.LogoUrl = dto.LogoUrl;
        await _repository.UpdateAsync(entity);

        return ApiResponse<SuccessPartnerDto>.Ok(MapToDto(entity, "en"), "Partner updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Partner deleted");
    }

    private SuccessPartnerDto MapToDto(SuccessPartner entity, string lang)
    {
        var dto = _mapper.Map<SuccessPartnerDto>(entity);
        dto.Name = GetLocalized(entity.TitleAr, entity.TitleEn, lang);
        return dto;
    }

    private static string GetLocalized(string ar, string en, string lang) => string.Equals(lang, "ar", System.StringComparison.OrdinalIgnoreCase) ? ar : en;
}
