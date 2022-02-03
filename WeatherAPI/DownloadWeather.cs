using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public class DownloaderWeather : IWeatherAPI
    {
        private readonly string URL;
        private readonly string Token;

        public DownloaderWeather()
        {
            URL = Settings.WeatherURL;
            Token = Settings.WeatherAPIToken;
        }

        private async Task<WeatherRoot> GetDataAsync(string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{URL}" +
                $"?lat={CoordinatConverter.GetLat(city)}" +
                $"&lon={CoordinatConverter.GetLon(city)}" +
                $"&appid={Token}"),
            };

            string body;

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }
            return ParsToJSON(body);

        }

        public async Task<Dictionary<string, string>> GetSimpleWeather(string at)
        {
            var weatherObject = await GetDataAsync(at);

            Dictionary<string, string> weatherSimple = new Dictionary<string, string>();
            weatherSimple.Add("City", weatherObject.Name);
            weatherSimple.Add("Weather", weatherObject.Weather[0]?.Description);
            weatherSimple.Add("Temprature", $"{weatherObject.Main.Temp} K , {weatherObject.Main.Temp - 273:f} С");

            return weatherSimple;
        }

        private WeatherRoot ParsToJSON(string body)
        {
            var deserializator = JsonConvert.DeserializeObject<WeatherRoot>(body);
            return deserializator;
        }
    }

    internal static class CoordinatConverter
    {
        internal static string GetLat(string city)
        {
            if (city == "London")
            {
                return "51.5";
            }
            else
            {
                return "0";
            }
        }

        internal static string GetLon(string city)
        {
            if (city == "London")
            {
                return "-0.12";
            }
            else
            {
                return "0";
            }
        }
    }

}
