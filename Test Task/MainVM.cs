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

        private Model Model;
        private string image;
        private string text;
        private string buttonText = "Узнать погоду";

        public MainVM(Model model)
        {
            Model = model;
            Model.WeatherChange += UpdateWeather;
            Model.ButtonUpdate.ButtonClick += UpdateButton;
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
            Model.ButtonUpdate.Click();
            Model.BildWeatherAsync();
        }

        private void UpdateWeather(Weather weather)
        {
            Text = $"{weather.City}\n{weather.Temrature}\n{weather.WeatherDiscription}";
            Image = weather.ImageURL;
        }
        private void UpdateButton(string text) => ButtonText = text;
    }
}
