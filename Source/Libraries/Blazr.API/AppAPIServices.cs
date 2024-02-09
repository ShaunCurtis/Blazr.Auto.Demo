using Blazr.OneWayStreet.Core;
using Microsoft.AspNetCore.Mvc;

namespace Blazr.Configuration;

public static class InfrastructureServices
{
    public static void AddAppEndPoints(this WebApplication app)
    {
        app.MapPost("/API/Weather/GetWeatherForecasts", async ([FromBody] ListRequest listRequest, IWeatherForecastProvider provider) =>
        {
            var result = await provider.GetWeatherForecastsAsync(listRequest);
            return result;
        });

        app.MapPost("/API/WeatherForecast/ListQuery", async ([FromBody] ListQueryRequest listRequest, IListRequestHandler<WeatherForecast> provider) =>
        {
            var result = await provider.ExecuteAsync(listRequest);
            return result;
        });
    }
}
