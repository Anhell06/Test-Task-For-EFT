using System;
using System.Windows;

namespace Test_Task
{

    public partial class MainWindow : Window
    {
        private ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            //Loader loadingFactory = new Loader(
            //    textLoader: new WeatherTextLoader(),
            //    imageUrlLoader: new WeatherImageLoader());
            //viewModel = new MainVM(new Model(loadingFactory));
            //DataContext = viewModel;
        }

        private void WeatherButtonClick(object sender, RoutedEventArgs e) => viewModel.Update();
    }
}
