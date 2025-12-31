using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gLiter.Infrastructure.Repositories;

public class JobApplicationRepository : GenericRepository<JobApplication>, IJobApplicationRepository
{
    public JobApplicationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<PagedResult<JobApplication>> GetByJobIdAsync(int jobId, int pageNumber, int pageSize)
    {
        var query = Context.Set<JobApplication>()
            .Include(a => a.Job)
            .Where(a => a.JobId == jobId)
            .OrderByDescending(a => a.AppliedAt);
            
        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            
        return new PagedResult<JobApplication> { Items = items, TotalCount = totalCount };
    }

    public async Task<PagedResult<JobApplication>> GetAllWithJobAsync(int pageNumber, int pageSize)
    {
        var query = Context.Set<JobApplication>()
            .Include(a => a.Job)
            .OrderByDescending(a => a.AppliedAt);
            
        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            
        return new PagedResult<JobApplication> { Items = items, TotalCount = totalCount };
    }
}
