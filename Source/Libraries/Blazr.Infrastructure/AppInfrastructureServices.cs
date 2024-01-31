using Blazr.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Blazr.Infrastructure;

public static class InfrastructureServices
{
    public static void AddAppServerInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastProvider, ServerWeatherForecastProvider>();
    }

    public static void AddAppWebAssemblyInfrastructureServices(this IServiceCollection services, string baseUrl)
    {
        services.AddScoped<IWeatherForecastProvider, APIWeatherForecastProvider>();
        services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(baseUrl));
    }
}
