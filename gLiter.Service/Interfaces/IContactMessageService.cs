using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IContactMessageService
{
    Task<PagedResponse<ContactMessageDto>> GetMessagesAsync(int pageNumber, int pageSize);
    Task<ApiResponse<ContactMessageDto>> GetByIdAsync(int id);
    Task<ApiResponse<ContactMessageDto>> CreateAsync(ContactMessageDto dto);
    Task<ApiResponse<ContactMessageDto>> MarkHandledAsync(int id, bool handled);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
