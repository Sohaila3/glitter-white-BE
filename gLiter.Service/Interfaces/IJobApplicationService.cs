using gLiter.Service.DTOs;

namespace gLiter.Service.Interfaces;

public interface IJobApplicationService
{
    Task<PagedResponse<JobApplicationDto>> GetApplicationsAsync(int pageNumber, int pageSize);
    Task<PagedResponse<JobApplicationDto>> GetByJobIdAsync(int jobId, int pageNumber, int pageSize);
    Task<ApiResponse<JobApplicationDto>> GetByIdAsync(int id);
    Task<ApiResponse<JobApplicationDto>> CreateAsync(JobApplicationDto dto);
    Task<ApiResponse<JobApplicationDto>> MarkReviewedAsync(int id, bool reviewed, string? notes = null);
    Task<ApiResponse<bool>> DeleteAsync(int id);
}
