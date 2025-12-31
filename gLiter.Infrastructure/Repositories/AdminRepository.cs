using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gLiter.Infrastructure.Repositories;

public class AdminRepository : GenericRepository<AdminUser>, IAdminRepository
{
    public AdminRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<AdminUser?> GetByUsernameAsync(string username)
    {
        var normalized = username.ToLower();
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Username.ToLower() == normalized);
    }

    public async Task<AdminUser?> GetByEmailAsync(string email)
    {
        var normalized = email.ToLower();
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Email.ToLower() == normalized);
    }

    public async Task<AdminUser?> GetByEmailOrUsernameAsync(string emailOrUsername)
    {
        var normalized = emailOrUsername.ToLower();
        return await DbSet.AsNoTracking()
            .FirstOrDefaultAsync(a => a.Email.ToLower() == normalized || a.Username.ToLower() == normalized);
    }

    public async Task<IEnumerable<AdminUser>> GetAllAdminsAsync()
    {
        return await DbSet.AsNoTracking()
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }
}
