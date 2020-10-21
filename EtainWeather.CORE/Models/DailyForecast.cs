using System;

namespace EtainWeather.CORE.Models
{
    public class DailyForecast
    {
        public long Id { get; set; }

        public DateTime ForecastDate { get; set; }

        public string State { get; set; }

        public string Image { get; set; }
    }
}
