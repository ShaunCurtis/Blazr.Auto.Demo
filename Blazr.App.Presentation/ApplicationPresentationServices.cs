/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
using Microsoft.Extensions.DependencyInjection;

namespace Blazr.App.Presentation;
public static class ApplicationPresentationServices
{
    public static void AddAppPresentationServices(this IServiceCollection services)
    {

        // Add any individual entity services
        services.AddTransient<WeatherForecastListPresenter>();
        services.AddTransient<WeatherForecastEditPresenter>();
    }
}
