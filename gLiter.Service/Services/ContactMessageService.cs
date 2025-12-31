using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class ContactMessageService : IContactMessageService
{
    private readonly IContactMessageRepository _repository;
    private readonly IMapper _mapper;

    public ContactMessageService(IContactMessageRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<ContactMessageDto>> GetMessagesAsync(int pageNumber, int pageSize)
    {
        var result = await _repository.GetPagedAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => _mapper.Map<ContactMessageDto>(e)).ToList();
        return PagedResponse<ContactMessageDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<ContactMessageDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<ContactMessageDto>.Fail("Message not found");
        }

        return ApiResponse<ContactMessageDto>.Ok(_mapper.Map<ContactMessageDto>(entity));
    }

    public async Task<ApiResponse<ContactMessageDto>> CreateAsync(ContactMessageDto dto)
    {
        var entity = _mapper.Map<ContactMessage>(dto);
        var created = await _repository.AddAsync(entity);
        return ApiResponse<ContactMessageDto>.Ok(_mapper.Map<ContactMessageDto>(created), "Message received");
    }

    public async Task<ApiResponse<ContactMessageDto>> MarkHandledAsync(int id, bool handled)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<ContactMessageDto>.Fail("Message not found");
        }

        entity.IsHandled = handled;
        await _repository.UpdateAsync(entity);
        return ApiResponse<ContactMessageDto>.Ok(_mapper.Map<ContactMessageDto>(entity), "Message updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Message deleted");
    }
}
