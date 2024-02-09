/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Core;

public class WeatherForecastEditContext
{
    public string Name => "WeatherForecast Edit Context";

    public Guid WeatherForecastUID { get; private set; }

    public string? Summary { get; set; }

    public int? TemperatureC { get; set; }

    public DateOnly? Date { get; set; }

    public WeatherForecastEditContext(WeatherForecast record)
    {
        this.WeatherForecastUID = record.WeatherForecastUID;
        this.Summary = record.Summary;
        this.TemperatureC = record.TemperatureC;
        this.Date = record.Date;
    }

    public WeatherForecast AsRecord => new()
    {
        WeatherForecastUID = WeatherForecastUID,
        Summary = Summary ?? "Not Set",
        Date = this.Date ?? DateOnly.FromDateTime(DateTime.Now),
        TemperatureC = this.TemperatureC ?? 0
    };
}
