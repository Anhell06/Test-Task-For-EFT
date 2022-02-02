using System;

namespace Test_Task
{
    public interface ILoader
    {
        event Action TaskEnded;
        event Action<Weather> WeatherChange;

        void BildWeatherAsync();
        void StopAllOperation();
    }
}