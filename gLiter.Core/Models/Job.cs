using System;

namespace gLiter.Core.Models;

public class Job : LocalizedEntity
{
    public string Location { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; set; }
}
