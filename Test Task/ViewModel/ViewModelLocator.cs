using Microsoft.Extensions.DependencyInjection;
using SearchImageAPI;
using WeatherAPI;

namespace Test_Task.ViewModel
{
    public class ViewModelLocator
    {
        private ServiceProvider serviceProvider;

        public ViewModelLocator()
        {
            serviceProvider = ConfigureServices().BuildServiceProvider();
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILoader, Loader>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<IWeatherAPI, DownloaderWeather>();
            services.AddSingleton<IImageAPI, SearchImagerURL>();

            return services;
        }

        public MainViewModel Main => serviceProvider.GetRequiredService<MainViewModel>();

    }
}