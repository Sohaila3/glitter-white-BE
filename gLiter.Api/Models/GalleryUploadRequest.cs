using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace gLiter.Api.Models;

public class GalleryUploadRequest
{
    [Required]
    public IFormFile File { get; set; } = default!;
}
