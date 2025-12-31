using System;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class FleetDto
{
    public int Id { get; set; }

    [Required]
    public string NameAr { get; set; } = string.Empty;

    [Required]
    public string NameEn { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
