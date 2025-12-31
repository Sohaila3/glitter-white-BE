using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gLiter.Infrastructure.Repositories;

public class TransportRequestRepository : GenericRepository<TransportRequest>, ITransportRequestRepository
{
    public TransportRequestRepository(AppDbContext context) : base(context)
    {
    }

    // Override GetByIdAsync to include images
    public new async Task<TransportRequest?> GetByIdAsync(int id)
    {
        return await DbSet.Include(t => t.Images).FirstOrDefaultAsync(t => t.Id == id);
    }
}
