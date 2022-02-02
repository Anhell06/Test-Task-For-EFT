using System;

namespace Test_Task
{
    public interface ILoadingFactory
    {
        event Action TaskEnded;
        event Action<Weather> WeatherChange;

        void BildWeatherAsync();
        void StopAllOperation();
    }
}