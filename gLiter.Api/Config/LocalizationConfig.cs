using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace gLiter.Api.Config;

public static class LocalizationConfig
{
    public static RequestLocalizationOptions GetOptions()
    {
        var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ar") };
        return new RequestLocalizationOptions
        {
            DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        };
    }
}
