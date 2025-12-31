using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace gLiter.Api.StartupExtensions;

public static class AddLocalizationExtension
{
    public static IServiceCollection AddLocalizationSetup(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ar") };
            options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

        return services;
    }
}
