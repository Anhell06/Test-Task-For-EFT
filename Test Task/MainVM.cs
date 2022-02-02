using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test_Task
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private enum ButtonType { Update, Cancel }
        private ButtonType buttonType = ButtonType.Update;

        private Model downloader;
        private string image;
        private string text;
        private string buttonText;

        public MainVM(Model model)
        {
            downloader = model;
            downloader.WeatherChange += UpdateWeather;
            ButtonText = "Узнать погоду";
        }

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

        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                NotifyPropertyChanged(nameof(ButtonText));
            }
        }

        public void Update()
        {
            if (buttonType == ButtonType.Update)
            {
                buttonType = ButtonType.Cancel;
                ButtonText = "Отмена";
                downloader.BildWeatherAsync();
            }
            else
            {
                buttonType = ButtonType.Update;
                ButtonText = "Узнать погоду";
                downloader.StopAllOperation();
            }
        }

        private void UpdateWeather(Weather weather)
        {
            Text = $"{weather.City}\n{weather.Temrature}\n{weather.WeatherDiscription}";
            Image = weather.ImageURL;
            buttonType = ButtonType.Update;
            ButtonText = "Узнать погоду";
        }
    }
}
