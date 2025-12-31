using System;
using gLiter.Infrastructure.Services;
using gLiter.Api.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gLiter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GalleryController : ControllerBase
{
    private readonly IGalleryService _galleryService;
    private readonly FileStorageService _fileStorageService;
    private const int MaxPageSize = 100;

    public GalleryController(IGalleryService galleryService, FileStorageService fileStorageService)
    {
        _galleryService = galleryService;
        _fileStorageService = fileStorageService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] string lang = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var (page, size) = NormalizePaging(pageNumber, pageSize);
        var result = await _galleryService.GetGalleryAsync(NormalizeLang(lang), page, size);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id, [FromQuery] string lang = "en")
    {
        var result = await _galleryService.GetByIdAsync(id, NormalizeLang(lang));
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] GalleryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var result = await _galleryService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] GalleryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var result = await _galleryService.UpdateAsync(id, dto);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _galleryService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpPost("upload")]
    [Authorize]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload([FromForm] GalleryUploadRequest request)
    {
        if (!ModelState.IsValid || request.File == null || request.File.Length == 0)
        {
            return BadRequest(ApiResponse<string>.Fail("No file uploaded"));
        }

        await using var stream = request.File.OpenReadStream();
        var relativeUrl = await _fileStorageService.SaveGalleryImageAsync(stream, request.File.FileName);
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var publicUrl = string.Concat(baseUrl, relativeUrl);
        return Ok(ApiResponse<string>.Ok(publicUrl, "Image uploaded"));
    }

    private static (int page, int size) NormalizePaging(int pageNumber, int pageSize)
    {
        var page = Math.Max(1, pageNumber);
        var size = Math.Clamp(pageSize, 1, MaxPageSize);
        return (page, size);
    }

    private static string NormalizeLang(string lang) => string.Equals(lang, "ar", StringComparison.OrdinalIgnoreCase) ? "ar" : "en";
}
