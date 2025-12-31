using System;

namespace gLiter.Core.Models;

public class JobApplication : BaseEntity
{
    public int JobId { get; set; }
    public Job? Job { get; set; }
    
    public string ApplicantName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string CoverLetter { get; set; } = string.Empty;
    public string? ResumeUrl { get; set; }
    
    public bool IsReviewed { get; set; } = false;
    public string? Notes { get; set; }
    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
}
