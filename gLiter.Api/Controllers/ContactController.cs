using System;
using gLiter.Core.Constants;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gLiter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactMessageService _contactService;
    private const int MaxPageSize = 100;

    public ContactController(IContactMessageService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Send([FromBody] ContactMessageDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var result = await _contactService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.CustomerService)]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var (page, size) = NormalizePaging(pageNumber, pageSize);
        var result = await _contactService.GetMessagesAsync(page, size);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.CustomerService)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _contactService.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPatch("{id:int}/handled")]
    [Authorize]
    public async Task<IActionResult> MarkHandled(int id, [FromQuery] bool handled = true)
    {
        var result = await _contactService.MarkHandledAsync(id, handled);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _contactService.DeleteAsync(id);
        return Ok(result);
    }

    private static (int page, int size) NormalizePaging(int pageNumber, int pageSize)
    {
        var page = Math.Max(1, pageNumber);
        var size = Math.Clamp(pageSize, 1, MaxPageSize);
        return (page, size);
    }
}
