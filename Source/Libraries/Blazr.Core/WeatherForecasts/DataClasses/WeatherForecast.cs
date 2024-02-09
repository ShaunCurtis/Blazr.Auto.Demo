namespace Blazr.Core;

public record WeatherForecast
{
    public Guid WeatherForecastUID { get; init; }
    public DateOnly Date { get; init; }
    public int TemperatureC { get; init; }
    public string? Summary { get; init; }
}

public static class WeatherForecastExtensions
{
    public static int TemperatureAsDegF(this int temperatureC)
        => 32 + (int)(temperatureC / 0.5556);
}