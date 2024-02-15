/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Presentation;

public class WeatherForecastListPresenter
{
    private IEnumerable<WeatherForecast>? _forecasts;
    private IListRequestHandler _listRequestHandler;

    public IEnumerable<WeatherForecast> WeatherForecasts => _forecasts?.AsEnumerable() ?? Enumerable.Empty<WeatherForecast>();

    public WeatherForecastListPresenter(IListRequestHandler listRequestHandler)
    {
        _listRequestHandler = listRequestHandler;
    }
    
    public async Task LoadAsync()
    {
        var result = await _listRequestHandler.ExecuteAsync<WeatherForecast>(new ListQueryRequest());
        _forecasts = result.Items;
    }

    public async ValueTask<ItemsProviderResult<WeatherForecast>> GetWeatherForecastsAsync(ItemsProviderRequest request)
    {
        var listRequest = new ListQueryRequest() { StartIndex = request.StartIndex, PageSize = request.Count };
        var result = await _listRequestHandler.ExecuteAsync<WeatherForecast>(listRequest);

        if (result.Successful)
            return new ItemsProviderResult<WeatherForecast>(result.Items, (int)result.TotalCount);

        return new ItemsProviderResult<WeatherForecast>(Enumerable.Empty<WeatherForecast>(), 0);
    }

}
