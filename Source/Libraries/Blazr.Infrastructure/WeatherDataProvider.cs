namespace Blazr.Infrastructure
{
    public class WeatherDataProvider
    {
        private static WeatherDataProvider? _instance;
        private List<WeatherForecast> _weatherForecasts;

        public IEnumerable<WeatherForecast> WeatherForecasts => _weatherForecasts.AsEnumerable();

        private WeatherDataProvider()
        {
            _weatherForecasts = PopulateWeatherForecasts();
        }

        private List<WeatherForecast> PopulateWeatherForecasts()
        {
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            return Enumerable.Range(1, 100).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToList();
        }

        public static WeatherDataProvider GetInstance()
        {
            if (_instance == null)
                _instance = new WeatherDataProvider();

            return _instance;
        }
    }
}
