using System;

namespace gLiter.Core.Models;

public class FuelPrice : LocalizedEntity
{
    public string FuelType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime EffectiveDate { get; set; } = DateTime.UtcNow;
}
