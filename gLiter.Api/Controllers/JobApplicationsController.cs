using System;
using gLiter.Core.Constants;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gLiter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
    private readonly IJobApplicationService _applicationService;
    private const int MaxPageSize = 100;

    public JobApplicationsController(IJobApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    /// <summary>
    /// Submit a job application (public)
    /// </summary>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Apply([FromBody] JobApplicationDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.Fail("Invalid input"));
        }

        var result = await _applicationService.CreateAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Get all applications (HR only)
    /// </summary>
    [HttpGet]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.HR)]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        var (page, size) = NormalizePaging(pageNumber, pageSize);
        var result = await _applicationService.GetApplicationsAsync(page, size);
        return Ok(result);
    }

    /// <summary>
    /// Get applications for a specific job (HR only)
    /// </summary>
    [HttpGet("job/{jobId:int}")]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.HR)]
    public async Task<IActionResult> GetByJob(int jobId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        var (page, size) = NormalizePaging(pageNumber, pageSize);
        var result = await _applicationService.GetByJobIdAsync(jobId, page, size);
        return Ok(result);
    }

    /// <summary>
    /// Get single application details (HR only)
    /// </summary>
    [HttpGet("{id:int}")]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.HR)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _applicationService.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    /// <summary>
    /// Mark application as reviewed (HR only)
    /// </summary>
    [HttpPatch("{id:int}/reviewed")]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.HR)]
    public async Task<IActionResult> MarkReviewed(int id, [FromQuery] bool reviewed = true, [FromQuery] string? notes = null)
    {
        var result = await _applicationService.MarkReviewedAsync(id, reviewed, notes);
        return result.Success ? Ok(result) : NotFound(result);
    }

    /// <summary>
    /// Delete an application (HR only)
    /// </summary>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = AdminRoles.SuperAdmin + "," + AdminRoles.HR)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _applicationService.DeleteAsync(id);
        return Ok(result);
    }

    private static (int page, int size) NormalizePaging(int pageNumber, int pageSize)
    {
        var page = Math.Max(1, pageNumber);
        var size = Math.Clamp(pageSize, 1, MaxPageSize);
        return (page, size);
    }
}
