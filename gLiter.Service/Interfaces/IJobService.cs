using System.Threading.Tasks;
using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IJobService
{
    Task<PagedResponse<JobDto>> GetJobsAsync(string lang, int pageNumber, int pageSize);
    Task<ApiResponse<JobDto>> GetByIdAsync(int id, string lang);
    Task<ApiResponse<JobDto>> CreateAsync(JobDto dto);
    Task<ApiResponse<JobDto>> UpdateAsync(int id, JobDto dto);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
