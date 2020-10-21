using Ardalis.GuardClauses;
using EtainWeather.CORE.Interfaces;
using EtainWeather.CORE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EtainWeather.CORE.Services
{
    public class WeatherService : IWeatherService
    {
        private const string BASE_ADDRESS = "https://www.metaweather.com";
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri($"{BASE_ADDRESS}/api/");
            _httpClient = httpClient;
        }

        public async Task<List<DailyForecast>> GetByLocation(string locationId)
        {
            // (1) Guard clauses
            Guard.Against.NullOrEmpty(locationId, nameof(locationId));

            if (!int.TryParse(locationId, out int woeid))
                throw new ArgumentException($"{woeid} is not a valid woeid location code.");

            // (2) Process json data from service
            var response = await _httpClient.GetAsync($"location/{woeid}");

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ExpandoObject>(json)
                                    .First(x => x.Key == "consolidated_weather")
                                    .Value;

            var list = result as IEnumerable<dynamic>;

            var consolidatedList = list.Take(5)
                                       .Select(x => new DailyForecast()
                                       {
                                           Id = x.id,
                                           State = x.weather_state_name,
                                           Image = $"{BASE_ADDRESS}/static/img/weather/png/64/{x.weather_state_abbr}.png",
                                           ForecastDate = Convert.ToDateTime(x.applicable_date)
                                       })
                                       .ToList();

            return consolidatedList;
        }
    }
}
