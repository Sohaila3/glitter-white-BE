using System;

namespace gLiter.Core.Models;

public class News : LocalizedEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; } = true;
}
