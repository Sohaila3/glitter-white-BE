using System;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class JobApplicationDto
{
    public int Id { get; set; }

    [Required]
    public int JobId { get; set; }

    [Required]
    [StringLength(100)]
    public string ApplicantName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string Phone { get; set; } = string.Empty;

    [StringLength(2000)]
    public string CoverLetter { get; set; } = string.Empty;

    public string? ResumeUrl { get; set; }

    public bool IsReviewed { get; set; }
    public string? Notes { get; set; }
    public DateTime AppliedAt { get; set; }
    
    // For display
    public string? JobTitle { get; set; }
}
