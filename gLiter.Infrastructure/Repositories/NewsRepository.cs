using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class NewsRepository : GenericRepository<News>, INewsRepository
{
    public NewsRepository(AppDbContext context) : base(context)
    {
    }
}
