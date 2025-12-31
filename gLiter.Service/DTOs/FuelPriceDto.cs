using System;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class FuelPriceDto
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
    public string FuelType { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    public DateTime EffectiveDate { get; set; }
    public DateTime CreatedAt { get; set; }
}
