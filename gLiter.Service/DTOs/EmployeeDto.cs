using System;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Service.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }

    [Required]
    public string NameAr { get; set; } = string.Empty;

    [Required]
    public string NameEn { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string PositionAr { get; set; } = string.Empty;
    public string PositionEn { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; } = 0;
    public DateTime CreatedAt { get; set; }
}
