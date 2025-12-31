using System;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class StationDto
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
    public string Address { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;

    [Phone]
    public string Phone { get; set; } = string.Empty;

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime CreatedAt { get; set; }
}
