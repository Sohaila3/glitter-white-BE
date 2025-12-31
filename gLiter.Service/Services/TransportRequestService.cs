using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class TransportRequestService : ITransportRequestService
{
    private readonly ITransportRequestRepository _repository;
    private readonly IMapper _mapper;

    public TransportRequestService(ITransportRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<TransportRequestDto>> GetRequestsAsync(int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        // Note: GetPagedAsync might not include images by default depending on implementation, 
        // but for list view maybe we don't need all images or we rely on lazy loading if enabled (not recommended)
        // or we should override GetPagedAsync in repo to include images if needed.
        // For now, let's assume basic info is enough or we accept N+1 if lazy loading is on (it's not usually).
        // Ideally, we should update repo to include images.
        
        var mapped = _mapper.Map<List<TransportRequestDto>>(result.Items);
        return PagedResponse<TransportRequestDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<TransportRequestDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<TransportRequestDto>.Fail("Request not found");
        }

        return ApiResponse<TransportRequestDto>.Ok(_mapper.Map<TransportRequestDto>(entity));
    }

    public async Task<ApiResponse<TransportRequestDto>> CreateAsync(CreateTransportRequestDto dto)
    {
        var entity = _mapper.Map<TransportRequest>(dto);
        
        if (dto.ImageUrls != null && dto.ImageUrls.Any())
        {
            entity.Images = dto.ImageUrls.Select(url => new TransportRequestImage { ImageUrl = url }).ToList();
        }

        var created = await _repository.AddAsync(entity);
        return ApiResponse<TransportRequestDto>.Ok(_mapper.Map<TransportRequestDto>(created), "Request submitted successfully");
    }

    public async Task<ApiResponse<bool>> MarkAsHandledAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<bool>.Fail("Request not found");
        }

        entity.IsHandled = true;
        await _repository.UpdateAsync(entity);
        return ApiResponse<bool>.Ok(true, "Request marked as handled");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Request deleted");
    }
}
