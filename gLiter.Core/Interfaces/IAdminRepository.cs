using System.Collections.Generic;
using System.Threading.Tasks;
using gLiter.Core.Models;

namespace gLiter.Core.Interfaces;

public interface IAdminRepository : IGenericRepository<AdminUser>
{
    Task<AdminUser?> GetByUsernameAsync(string username);
    Task<AdminUser?> GetByEmailAsync(string email);
    Task<AdminUser?> GetByEmailOrUsernameAsync(string emailOrUsername);
    Task<IEnumerable<AdminUser>> GetAllAdminsAsync();
}
