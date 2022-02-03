using SearchImageAPI;
using System;
using System.Collections.Generic;
using System.Threading;
using WeatherAPI;

namespace Test_Task
{
    public class Loader : ILoader
    {
        public event Action<Weather> WeatherLoaded;
        public event Action LoadStoped;

        private IWeatherAPI weatherLoader;
        private IImageAPI imageUrlLoader;
        private CancellationTokenSource cts;

        public Loader(IWeatherAPI weatherLoader, IImageAPI imageUrlLoader)
        {
            this.weatherLoader = weatherLoader;
            this.imageUrlLoader = imageUrlLoader;
        }

        public async void LoadWeather(string city)
        {
            cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            Dictionary<string, string> weatherData = new Dictionary<string, string>();

            try
            {
                weatherData = await weatherLoader.GetSimpleWeather(at: city);
                string URL = await imageUrlLoader.GetImageURL(weatherData["Weather"]);
                weatherData.Add("URL", URL);
            }
            catch (Exception)
            {
                cts.Cancel();
            }

            if (ct.IsCancellationRequested)
            {
                LoadStoped?.Invoke();
                return;
            }

            Weather weather = CreateWeather(weatherData);

            WeatherLoaded?.Invoke(weather);
            LoadStoped?.Invoke();
        }

        private static Weather CreateWeather(Dictionary<string, string> weather)
        {
            var weatherModel = new Weather();
            weatherModel.City = "City " + weather["City"];
            weatherModel.WeatherDiscription = "Weather " + weather["Weather"];
            weatherModel.Temrature = "Temprature " + weather["Temprature"];
            weatherModel.ImageURL = weather["URL"];
            return weatherModel;
        }

        public void StopLoad()
        {
            cts?.Cancel();
        }
    }
}
