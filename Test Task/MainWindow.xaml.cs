using System.Windows;

namespace Test_Task
{

    public partial class MainWindow : Window
    {
        private MainVM viewModel;

        public MainWindow()
        {
            InitializeComponent();

            LoadingFactory loadingFactory = new LoadingFactory(
                textLoader: new WeatherTextLoader(Settings.WeatherURLApi, Settings.WeatherAPIToken),
                imageUrlLoader: new WeatherImageLoader(Settings.ImageURLApi));
            viewModel = new MainVM(new Model(loadingFactory));

            DataContext = viewModel;
        }

        private void WeatherButtonClick(object sender, RoutedEventArgs e) => viewModel.Update();
    }
}
