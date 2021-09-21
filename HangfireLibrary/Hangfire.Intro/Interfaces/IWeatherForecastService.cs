using Hangfire.Intro.Models;
using System.Collections.Generic;

namespace Hangfire.Intro.Interfaces
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
