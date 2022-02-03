using NUnit.Framework;
using System.Collections.Generic;
using WeatherAPI;

namespace TestWeatherAPI
{
    public class DownloadWeather_CanDownloadFile
    {
        private DownloaderWeather downolader;
        [SetUp]
        public void Setup()
        {
            downolader = new DownloaderWeather();
        }

        [Test]
        public void Test1()
        {
            var weatherAPI = downolader.GetSimpleWeather("London").Result;

            Assert.IsFalse(!weatherAPI.ContainsKey("Weather"));
            Assert.IsFalse(!weatherAPI.ContainsKey("Temprature"));
            Assert.IsFalse(!weatherAPI.ContainsKey("City"));
        }
    }
}