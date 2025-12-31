using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface ITransportRequestService
{
    Task<PagedResponse<TransportRequestDto>> GetRequestsAsync(int pageNumber, int pageSize);
    Task<ApiResponse<TransportRequestDto>> GetByIdAsync(int id);
    Task<ApiResponse<TransportRequestDto>> CreateAsync(CreateTransportRequestDto dto);
    Task<ApiResponse<bool>> MarkAsHandledAsync(int id);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
