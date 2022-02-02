using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test_Task
{
    public class Model : IModel
    {
        public event Action<Weather> WeatherChange;

        private ITextLoader textLoader;
        private ITextLoader imageUrlLoader;
        CancellationTokenSource cts;

        public ButtonUpdate ButtonUpdate { get; private set; }
        
        public Model(ITextLoader textLoader, ITextLoader imageUrlLoader)
        {
            this.textLoader = textLoader;
            this.imageUrlLoader = imageUrlLoader;
            ButtonUpdate = new ButtonUpdate();
            ButtonUpdate.CancelClick += StopAllOperation;
            ButtonUpdate.UpdateClick += BildWeatherAsync;
        }

        private async void BildWeatherAsync()
        {
            cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            string weatherData = await StartBildTask(textLoader);

            if (ct.IsCancellationRequested)
            {
                ButtonUpdate.Refresh();
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
                ButtonUpdate.Refresh();
                return;
            }
            ButtonUpdate.Refresh();
            WeatherChange?.Invoke(weather);
        }

        private async Task<string> StartBildTask(ITextLoader loader, params string[] parametrs)
        {
            return await loader.GetDataAsync(parametrs);
        }

        private void StopAllOperation()
        {
            cts?.Cancel();
        }
    }
}
