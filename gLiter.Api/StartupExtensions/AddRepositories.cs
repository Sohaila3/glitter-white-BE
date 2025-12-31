using gLiter.Core.Interfaces;
using gLiter.Infrastructure.Repositories;
using gLiter.Infrastructure.Services;

namespace gLiter.Api.StartupExtensions;

public static class AddRepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IStationRepository, StationRepository>();
        services.AddScoped<IFuelPriceRepository, FuelPriceRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IGalleryRepository, GalleryRepository>();
        services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IHeroSectionRepository, HeroSectionRepository>();
        services.AddScoped<ITransportRequestRepository, TransportRequestRepository>();
        services.AddScoped<IFleetRepository, FleetRepository>();
        services.AddScoped<ISuccessPartnerRepository, SuccessPartnerRepository>();
        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<FileStorageService>();
        return services;
    }
}
