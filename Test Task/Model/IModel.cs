using System;

namespace Test_Task
{
    public interface IModel
    {
        ButtonUpdate ButtonUpdate { get; }

        event Action<Weather> WeatherChange;
    }
}