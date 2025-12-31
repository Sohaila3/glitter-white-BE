using System;
using System.Threading.Tasks;
using gLiter.Core.Constants;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gLiter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransportRequestController : ControllerBase
{
    private readonly ITransportRequestService _service;
    private const int MaxPageSize = 100;

    public TransportRequestController(ITransportRequestService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var (page, size) = NormalizePaging(pageNumber, pageSize);
        var result = await _service.GetRequestsAsync(page, size);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateTransportRequestDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id:int}/handle")]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.CustomerService)]
    public async Task<IActionResult> MarkAsHandled(int id)
    {
        var result = await _service.MarkAsHandledAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.CustomerService)]
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
}
