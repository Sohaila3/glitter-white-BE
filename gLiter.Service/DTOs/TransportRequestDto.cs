using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class TransportRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsHandled { get; set; }
    public List<string> ImageUrls { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class CreateTransportRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    public List<string> ImageUrls { get; set; } = new();
}
