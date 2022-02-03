using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Test_Task.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string City = "London";

        private ILoader loader;
        private string image;
        private string text;
        private string buttonText;
        private RelayCommand commandButton;
        private RelayCommand startCommand;
        private RelayCommand stopCommand;

        public MainViewModel(ILoader loader)
        {

            startCommand = new RelayCommand(StartDownload);
            stopCommand = new RelayCommand(StopDownload);

            UpdateButton("Узнать погоду", startCommand);

            this.loader = loader;
            loader.LoadStoped += () => UpdateButton("Узнать погоду", startCommand);
            loader.WeatherLoaded += UpdateWeather;

        }

        public RelayCommand ComandButton
        {
            get => commandButton;
            set
            {
                commandButton = value;
                RaisePropertyChanged();
            }
        }
        public string Image
        {
            get => image;
            set
            {
                image = value;
                RaisePropertyChanged();
            }
        }
        public string Text
        {
            get => text;
            set
            {
                text = value;
                RaisePropertyChanged();
            }
        }
        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                RaisePropertyChanged();
            }
        }
        private void StartDownload()
        {
            UpdateButton("Отмена", stopCommand);
            loader.LoadWeather(City);
        }
        private void StopDownload()
        {
            UpdateButton("Узнать погоду", startCommand);
            loader.StopLoad();
        }
        private void UpdateButton(string text, RelayCommand command)
        {
            ButtonText = text;
            ComandButton = command;
        }
        private void UpdateWeather(Weather weather)
        {
            Text = $"{weather.City}\n{weather.Temrature}\n{weather.WeatherDiscription}";
            Image = weather.ImageURL;
        }
    }
}