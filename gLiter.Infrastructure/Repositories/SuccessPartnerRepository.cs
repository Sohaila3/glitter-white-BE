using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class SuccessPartnerRepository : GenericRepository<SuccessPartner>, ISuccessPartnerRepository
{
    public SuccessPartnerRepository(AppDbContext context) : base(context)
    {
    }
}
