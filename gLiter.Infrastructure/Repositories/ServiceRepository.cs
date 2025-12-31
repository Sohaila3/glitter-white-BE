using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class ServiceRepository : GenericRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }
}
