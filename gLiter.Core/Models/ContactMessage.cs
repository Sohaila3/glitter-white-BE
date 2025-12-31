using System;

namespace gLiter.Core.Models;

public class ContactMessage : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsHandled { get; set; } = false;
    public bool PrivacyPolicyAccepted { get; set; } = false;
}
