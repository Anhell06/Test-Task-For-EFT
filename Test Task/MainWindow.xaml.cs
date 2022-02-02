using System.Windows;

namespace Test_Task
{

    public partial class MainWindow : Window
    {
        private MainVM viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainVM(new Model(
                new WeatherTextLoader(Settings.WeatherURLApi, Settings.WeatherAPIToken), 
                new WeatherImageLoader(Settings.ImageURLApi)));
            DataContext = viewModel;
        }

        private void CheckTheWeatherButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Update();
        }
    }
}
