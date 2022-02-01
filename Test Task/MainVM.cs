using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test_Task
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private readonly ITextLoader textLoader = new WeatherTextLoader("http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=", "5b0857721488c3d373ecdbfb57e8a57f");
        private readonly ITextLoader imageLoader = new WeatherImageLoader();
        private readonly Downloader downloader = new Downloader();

        private string image;
        private string text;

        public string Image
        {
            get => image;
            set
            {
                image = value;
                NotifyPropertyChanged(nameof(Image));
            }
        }
        public string Text
        {
            get => text;
            set
            {
                text = value;
                NotifyPropertyChanged(nameof(Text));
            }
        }

        public async void Update()
        {
            Text = await downloader.StartAsync(textLoader);
            Image = await downloader.StartAsync(imageLoader);
        }
    }
}
