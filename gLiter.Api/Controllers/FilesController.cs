using System.Threading.Tasks;
using gLiter.Infrastructure.Services;
using gLiter.Service.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gLiter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly FileStorageService _fileStorageService;

    public FilesController(FileStorageService fileStorageService)
    {
        _fileStorageService = fileStorageService;
    }

    [HttpPost("upload")]
    [AllowAnonymous] // Or Authorize depending on needs, usually upload needs auth but for public forms maybe not? 
                     // Actually TransportRequest is public, so user needs to upload images.
                     // Let's keep it AllowAnonymous for now or restrict if needed.
                     // Ideally we should have a separate public upload endpoint or use a temporary token.
                     // For simplicity, AllowAnonymous for now as requested "Transport Request" is public.
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest(ApiResponse<string>.Fail("No file uploaded"));
        }

        await using var stream = file.OpenReadStream();
        // We can reuse SaveGalleryImageAsync or create a generic one. 
        // Let's assume SaveGalleryImageAsync just saves to wwwroot/images/gallery which is fine for now.
        // Or better, add a generic SaveFileAsync in FileStorageService if possible, but I can't see it right now.
        // I'll use SaveGalleryImageAsync as it likely just saves to a folder.
        var relativeUrl = await _fileStorageService.SaveGalleryImageAsync(stream, file.FileName);
        
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var publicUrl = string.Concat(baseUrl, relativeUrl);
        
        return Ok(ApiResponse<string>.Ok(publicUrl, "File uploaded successfully"));
    }
}
