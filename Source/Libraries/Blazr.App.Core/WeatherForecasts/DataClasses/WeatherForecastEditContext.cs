﻿/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Core;

public class WeatherForecastEditContext
{
    public string Name => "WeatherForecast Edit Context";

    private WeatherForecast _baseRecord;
    
    public Guid WeatherForecastUID { get; private set; }

    public string? Summary { get; set; }

    public int? TemperatureC { get; set; }

    public DateOnly? Date { get; set; }

    public bool IsNew { get; private set; }

    public bool IsMutated => _baseRecord != this.AsRecord;
    public bool IsClean => _baseRecord == this.AsRecord;

    public WeatherForecastEditContext(WeatherForecast record)
    {
        _baseRecord = record;
        this.LoadFromBase();
    }

    public void Reset()
        => this.LoadFromBase();

    private void LoadFromBase()
    {
        this.WeatherForecastUID = _baseRecord.WeatherForecastUID;
        this.Summary = _baseRecord.Summary;
        this.TemperatureC = _baseRecord.TemperatureC;
        this.Date = _baseRecord.Date;
    }

    public WeatherForecast AsRecord => new()
    {
        WeatherForecastUID = WeatherForecastUID,
        Summary = Summary ?? "Not Set",
        Date = this.Date ?? DateOnly.FromDateTime(DateTime.Now),
        TemperatureC = this.TemperatureC ?? 0
    };

    public static WeatherForecastEditContext AsNew()
    {
        return new(new()
        {
            WeatherForecastUID = Guid.NewGuid()
        })
        { IsNew = true }; 
    }

    public CommandState GetCommandState()
    {
        if (this.IsNew)
            return CommandState.Add;

        if (this.IsMutated)
            return CommandState.Update;

        return CommandState.None;
    }
}
