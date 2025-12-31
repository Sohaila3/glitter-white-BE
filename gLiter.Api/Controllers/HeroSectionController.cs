using System;
using System.Threading.Tasks;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gLiter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroSectionController : ControllerBase
{
    private readonly IHeroSectionService _service;
    private const int MaxPageSize = 100;

    public HeroSectionController(IHeroSectionService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] string lang = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var (page, size) = NormalizePaging(pageNumber, pageSize);
        var result = await _service.GetHeroSectionsAsync(NormalizeLang(lang), page, size);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id, [FromQuery] string lang = "en")
    {
        var result = await _service.GetByIdAsync(id, NormalizeLang(lang));
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] HeroSectionDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] HeroSectionDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var result = await _service.UpdateAsync(id, dto);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    private static (int page, int size) NormalizePaging(int pageNumber, int pageSize)
    {
        var page = Math.Max(1, pageNumber);
        var size = Math.Clamp(pageSize, 1, MaxPageSize);
        return (page, size);
    }

    private static string NormalizeLang(string lang) => string.Equals(lang, "ar", StringComparison.OrdinalIgnoreCase) ? "ar" : "en";
}
