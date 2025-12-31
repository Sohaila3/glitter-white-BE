using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class GalleryRepository : GenericRepository<GalleryImage>, IGalleryRepository
{
    public GalleryRepository(AppDbContext context) : base(context)
    {
    }
}
