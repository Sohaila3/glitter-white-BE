using System;

namespace gLiter.Service.DTOs;

public class AdminResponseDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsPrimary { get; set; }
    public DateTime CreatedAt { get; set; }
    // optional metadata about who created this admin
    public int? CreatedById { get; set; }
    public string CreatedByName { get; set; } = string.Empty;
}
