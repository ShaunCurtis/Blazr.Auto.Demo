namespace Blazr.Core;

public interface IWeatherForecastProvider
{
    public Task<ListResult<WeatherForecast>> GetWeatherForecastsAsync(ListRequest request, CancellationToken? cancellationToken = null);
}
