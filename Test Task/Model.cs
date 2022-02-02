using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test_Task
{
    public class Model
    {
        public event Action<Weather> WeatherChange;

        private List<CancellationTokenSource> tokens = new List<CancellationTokenSource>();
        private ITextLoader textLoader;
        private ITextLoader imageUrlLoader;

        public ButtonUpdate ButtonUpdate { get; private set; }
        //public Factory factory { get; private set; }

        public Model(ITextLoader textLoader, ITextLoader imageUrlLoader)
        {
            this.textLoader = textLoader;
            this.imageUrlLoader = imageUrlLoader;
            ButtonUpdate = new ButtonUpdate();
            //factory = new Factory();
        }

        public async void BildWeatherAsync()
        {
            var cts = new CancellationTokenSource();
            tokens.Add(cts);

            if (cts.IsCancellationRequested)
                return;

            string weatherData = await StartBildTask(textLoader);

            string[] weatherDatas = weatherData.Split('\n');
            Weather weather = new Weather();
            weather.City = weatherDatas[0];
            weather.WeatherDiscription = weatherDatas[1];
            weather.Temrature = weatherDatas[2] + weatherDatas[3];

            if (cts.IsCancellationRequested)
                return;

            weather.ImageURL = await StartBildTask(imageUrlLoader, $"q={weather.WeatherDiscription}");

            if (cts.IsCancellationRequested)
                return;

            ButtonUpdate.Refresh();
            WeatherChange?.Invoke(weather);
        }

        private async Task<string> StartBildTask(ITextLoader loader, params string[] parametrs)
        {
            return await loader.GetDataAsync(parametrs);
        }

        public void StopAllOperation()
        {
            foreach (var cts in tokens)
            {
                cts?.Cancel();
            }

            tokens.Clear();
        }
    }
}
