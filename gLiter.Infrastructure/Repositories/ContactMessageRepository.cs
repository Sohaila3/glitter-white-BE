using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;

namespace gLiter.Infrastructure.Repositories;

public class ContactMessageRepository : GenericRepository<ContactMessage>, IContactMessageRepository
{
    public ContactMessageRepository(AppDbContext context) : base(context)
    {
    }
}
