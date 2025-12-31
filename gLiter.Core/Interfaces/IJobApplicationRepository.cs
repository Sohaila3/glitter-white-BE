using gLiter.Core.Models;

namespace gLiter.Core.Interfaces;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<PagedResult<JobApplication>> GetByJobIdAsync(int jobId, int pageNumber, int pageSize);
    Task<PagedResult<JobApplication>> GetAllWithJobAsync(int pageNumber, int pageSize);
}
