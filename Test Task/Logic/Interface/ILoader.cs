using System;

namespace Test_Task
{
    public interface ILoader
    {
        event Action<Weather> WeatherLoaded;
        event Action LoadStoped;
        void LoadWeather(string city);
        void StopLoad();
    }
}