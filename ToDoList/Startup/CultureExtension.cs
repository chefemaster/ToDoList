using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace UI.ToDoList.Startup;
public static class CultureExtension
{
    public static IApplicationBuilder UseCulturePtBr(this IApplicationBuilder app)
    {
        var defaultCulture = new CultureInfo("pt-BR");

        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(defaultCulture),
            SupportedCultures = new List<CultureInfo> { defaultCulture },
            SupportedUICultures = new List<CultureInfo> { defaultCulture },
        };

        app.UseRequestLocalization(localizationOptions);
        return app;
    }
}