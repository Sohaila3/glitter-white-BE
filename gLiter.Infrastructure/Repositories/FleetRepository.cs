using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class FleetRepository : GenericRepository<FleetVehicle>, IFleetRepository
{
    public FleetRepository(AppDbContext context) : base(context)
    {
    }
}
