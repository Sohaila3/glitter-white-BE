using gLiter.Service.Interfaces;
using gLiter.Service.Mapping;
using gLiter.Service.Services;

namespace gLiter.Api.StartupExtensions;

public static class AddServicesExtension
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IStationService, StationService>();
        services.AddScoped<IFuelPriceService, FuelPriceService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IGalleryService, GalleryService>();
        services.AddScoped<IContactMessageService, ContactMessageService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IHeroSectionService, HeroSectionService>();
        services.AddScoped<ITransportRequestService, TransportRequestService>();
        services.AddScoped<IFleetService, FleetService>();
        services.AddScoped<ISuccessPartnerService, SuccessPartnerService>();
        services.AddScoped<IJobApplicationService, JobApplicationService>();
        services.AddScoped<IEmployeeService, EmployeeService>();

        services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        return services;
    }
}
