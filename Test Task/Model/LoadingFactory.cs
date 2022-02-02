using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test_Task
{
    public class Loader : ILoader
    {
        public event Action<Weather> WeatherChange;
        public event Action TaskEnded;

        private ITextLoader textLoader;
        private ITextLoader imageUrlLoader;
        private CancellationTokenSource cts;

        public Loader(ITextLoader textLoader, ITextLoader imageUrlLoader)
        {
            this.textLoader = textLoader;
            this.imageUrlLoader = imageUrlLoader;
        }

        public async void BildWeatherAsync()
        {
            cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            string weatherData = await StartBildTask(textLoader);

            if (ct.IsCancellationRequested)
            {
                TaskEnded?.Invoke();
                return;
            }

            string[] weatherDatas = weatherData.Split('\n');
            Weather weather = new Weather();
            weather.City = weatherDatas[0];
            weather.WeatherDiscription = weatherDatas[1];
            weather.Temrature = weatherDatas[2] + weatherDatas[3];

            weather.ImageURL = await StartBildTask(imageUrlLoader, $"q={weather.WeatherDiscription}");

            if (ct.IsCancellationRequested)
            {
                TaskEnded?.Invoke();
                return;
            }

            WeatherChange?.Invoke(weather);
            TaskEnded?.Invoke();
        }
        public void StopAllOperation()
        {
            cts?.Cancel();
        }

        private async Task<string> StartBildTask(ITextLoader loader, params string[] parametrs)
        {
            return await loader.GetDataAsync(parametrs);
        }

    }
}
