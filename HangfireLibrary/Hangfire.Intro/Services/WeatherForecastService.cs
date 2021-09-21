using Hangfire.Intro.Interfaces;
using Hangfire.Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Intro.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        //public WeatherForecastService(IWeatherForecastService forecastService)
        //{

        //}

        private static readonly string[] Summaries = new[]
{
            "Congelante", "Refrescante", "Frío", "Mucho Frío", "Suave", "Cálido", "Caluroso", "Sofocante"
        };

        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
