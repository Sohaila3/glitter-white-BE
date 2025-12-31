using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class AdminLoginDto
{
    [Required]
    public string EmailOrUsername { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
