using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_Task
{

    public partial class MainWindow : Window
    {
        private MainVM viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainVM(new Model(
                new WeatherTextLoader("http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=", "5b0857721488c3d373ecdbfb57e8a57f"), 
                new WeatherImageLoader("https://bing-image-search1.p.rapidapi.com/images/search")));
            DataContext = viewModel;
        }

        private void CheckTheWeatherButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Update();
        }
    }
}
