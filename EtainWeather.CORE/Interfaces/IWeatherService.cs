using EtainWeather.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtainWeather.CORE.Interfaces
{
    public interface IWeatherService
    {
        Task<List<DailyForecast>> GetByLocation(string locationId);
    }
}
