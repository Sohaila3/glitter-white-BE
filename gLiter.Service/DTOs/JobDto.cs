using System;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class JobDto
{
    public int Id { get; set; }

    [Required]
    public string TitleAr { get; set; } = string.Empty;

    [Required]
    public string TitleEn { get; set; } = string.Empty;

    [Required]
    public string DescriptionAr { get; set; } = string.Empty;

    [Required]
    public string DescriptionEn { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;

    public bool IsActive { get; set; }
    public DateTime PostedAt { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
