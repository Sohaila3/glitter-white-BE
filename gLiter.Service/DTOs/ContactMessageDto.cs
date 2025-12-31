using System;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class ContactMessageDto
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    [Required]
    public string Message { get; set; } = string.Empty;

    public bool IsHandled { get; set; }
    public bool PrivacyPolicyAccepted { get; set; }
    public DateTime CreatedAt { get; set; }
}
