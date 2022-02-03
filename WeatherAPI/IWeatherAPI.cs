using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public interface IWeatherAPI
    {
        Task<Dictionary<string, string>> GetSimpleWeather(string at);
    }
}