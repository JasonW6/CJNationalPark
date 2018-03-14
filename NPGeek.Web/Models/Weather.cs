using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }

        public string ForecastImageName
        {
            get
            {
                return imageNameFromForecast[Forecast];
            }
        }

        public List<string> GetAdvisories()
        {
            List<string> advisories = new List<string>();

            if (Forecast == "snow")
            {
                advisories.Add("Pack snowshows.");
            }
            if (Forecast == "rain")
            {
                advisories.Add("Pack rain gear and wear waterproof shoes.");
            }
            if (Forecast == "thunderstorms")
            {
                advisories.Add("Seek shelter and avoid hiking on exposed ridges.");
            }
            if (Forecast == "sunny")
            {
                advisories.Add("Pack sunblock.");
            }
            if (High > 75)
            {
                advisories.Add("Bring an extra gallon of water.");
            }
            if (High - Low > 20)
            {
                advisories.Add("Wear breathable layers.");
            }
            if (Low < 20)
            {
                advisories.Add("Frigid temperatures. Danger, use appropriate caution.");
            }

            return advisories;
        }

        private Dictionary<string, string> imageNameFromForecast = new Dictionary<string, string>()
        {
            { "cloudy", "cloudy.png" },
            { "partly cloudy", "partlyCloudy.png" },
            { "rain", "rain.png" },
            { "snow", "snow.png" },
            { "sunny", "sunny.png" },
            { "thunderstorms", "thunderstorms.png" }
        };
    }
}