using AutoMapper;
using gLiter.Core.Interfaces;
using gLiter.Core.Models;
using gLiter.Service.DTOs;
using gLiter.Service.Interfaces;

namespace gLiter.Service.Services;

public class JobApplicationService : IJobApplicationService
{
    private readonly IJobApplicationRepository _repository;
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;

    public JobApplicationService(IJobApplicationRepository repository, IJobRepository jobRepository, IMapper mapper)
    {
        _repository = repository;
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<JobApplicationDto>> GetApplicationsAsync(int pageNumber, int pageSize)
    {
        var result = await _repository.GetAllWithJobAsync(pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e)).ToList();
        return PagedResponse<JobApplicationDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<PagedResponse<JobApplicationDto>> GetByJobIdAsync(int jobId, int pageNumber, int pageSize)
    {
        var result = await _repository.GetByJobIdAsync(jobId, pageNumber, pageSize);
        var mapped = result.Items.Select(e => MapToDto(e)).ToList();
        return PagedResponse<JobApplicationDto>.Ok(mapped, pageNumber, pageSize, result.TotalCount);
    }

    public async Task<ApiResponse<JobApplicationDto>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<JobApplicationDto>.Fail("Application not found");
        }
        return ApiResponse<JobApplicationDto>.Ok(MapToDto(entity));
    }

    public async Task<ApiResponse<JobApplicationDto>> CreateAsync(JobApplicationDto dto)
    {
        var job = await _jobRepository.GetByIdAsync(dto.JobId);
        if (job == null || !job.IsActive)
        {
            return ApiResponse<JobApplicationDto>.Fail("Job not found or not active");
        }

        var entity = new JobApplication
        {
            JobId = dto.JobId,
            ApplicantName = dto.ApplicantName,
            Email = dto.Email,
            Phone = dto.Phone,
            CoverLetter = dto.CoverLetter,
            ResumeUrl = dto.ResumeUrl,
            AppliedAt = DateTime.UtcNow
        };

        var created = await _repository.AddAsync(entity);
        return ApiResponse<JobApplicationDto>.Ok(MapToDto(created), "Application submitted successfully");
    }

    public async Task<ApiResponse<JobApplicationDto>> MarkReviewedAsync(int id, bool reviewed, string? notes = null)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return ApiResponse<JobApplicationDto>.Fail("Application not found");
        }

        entity.IsReviewed = reviewed;
        if (notes != null) entity.Notes = notes;
        await _repository.UpdateAsync(entity);
        return ApiResponse<JobApplicationDto>.Ok(MapToDto(entity), "Application updated");
    }

    public async Task<ApiResponse<bool>> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return ApiResponse<bool>.Ok(true, "Application deleted");
    }

    private JobApplicationDto MapToDto(JobApplication entity)
    {
        return new JobApplicationDto
        {
            Id = entity.Id,
            JobId = entity.JobId,
            ApplicantName = entity.ApplicantName,
            Email = entity.Email,
            Phone = entity.Phone,
            CoverLetter = entity.CoverLetter,
            ResumeUrl = entity.ResumeUrl,
            IsReviewed = entity.IsReviewed,
            Notes = entity.Notes,
            AppliedAt = entity.AppliedAt,
            JobTitle = entity.Job?.TitleEn ?? entity.Job?.TitleAr ?? ""
        };
    }
}
