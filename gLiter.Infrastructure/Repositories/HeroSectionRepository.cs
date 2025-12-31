using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class HeroSectionRepository : GenericRepository<HeroSection>, IHeroSectionRepository
{
    public HeroSectionRepository(AppDbContext context) : base(context)
    {
    }
}
