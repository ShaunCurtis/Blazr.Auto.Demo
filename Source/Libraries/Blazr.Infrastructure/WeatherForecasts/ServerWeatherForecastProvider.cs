namespace Blazr.Infrastructure;

public class ServerWeatherForecastProvider : IWeatherForecastProvider
{
    public Task<ListResult<WeatherForecast>> GetWeatherForecastsAsync(ListRequest request, CancellationToken? cancellationToken = null)
    {
        var _provider = WeatherDataProvider.GetInstance();

        var query = _provider.WeatherForecasts
            .Skip(request.StartIndex)
            .Take(request.PageSize);

        var totalCount = query.Count();

        return Task.FromResult(ListResult<WeatherForecast>.Success(query, totalCount));
    }
}
