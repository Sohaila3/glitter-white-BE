using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class FuelPriceRepository : GenericRepository<FuelPrice>, IFuelPriceRepository
{
    public FuelPriceRepository(AppDbContext context) : base(context)
    {
    }
}
