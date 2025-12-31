using System;
using gLiter.Core.Constants;

namespace gLiter.Core.Models;

public class AdminUser : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public string Role { get; set; } = AdminRoles.SuperAdmin;
    public bool IsActive { get; set; } = true;
    // Mark primary/original admins that cannot be deleted or deactivated
    public bool IsPrimary { get; set; } = false;
    // Track which admin created this account (optional)
    public int? CreatedById { get; set; }
    public string CreatedByName { get; set; } = string.Empty;
}
