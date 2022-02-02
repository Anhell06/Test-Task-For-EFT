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
                textLoader: new WeatherTextLoader(Settings.WeatherURLApi, Settings.WeatherAPIToken),
                imageUrlLoader: new WeatherImageLoader(Settings.ImageURLApi)));
            DataContext = viewModel;
        }

        private void WeatherButtonClick(object sender, RoutedEventArgs e) => viewModel.Update();
    }
}
