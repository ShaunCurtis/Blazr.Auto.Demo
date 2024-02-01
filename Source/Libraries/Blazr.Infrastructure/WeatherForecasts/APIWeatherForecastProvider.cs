using System.Net.Http.Json;

namespace Blazr.Infrastructure;

public class APIWeatherForecastProvider : IWeatherForecastProvider
{
    private IHttpClientFactory _httpClientFactory;
    private List<WeatherForecast>? _forecasts;

    public APIWeatherForecastProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ListResult<WeatherForecast>> GetWeatherForecastsAsync(ListRequest request, CancellationToken? cancellationToken = null)
    {
        using var httpClient = _httpClientFactory.CreateClient("ServerAPI");

        var httpResult = await httpClient.PostAsJsonAsync<ListRequest>("/API/Weather/GetWeatherForecasts", request, cancellationToken ?? new());

        if (httpResult.IsSuccessStatusCode)
        {
            var listResult = await httpResult.Content.ReadFromJsonAsync<ListResult<WeatherForecast>>();
            return listResult;
        }
        return ListResult<WeatherForecast>.Failure($"Request failed.  Error Code: {httpResult.StatusCode.ToString()}");
    }
}
