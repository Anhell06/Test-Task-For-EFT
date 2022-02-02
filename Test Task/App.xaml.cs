using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows;

namespace Test_Task
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILoader, Loader>();
            services.AddSingleton<ViewModel>();
            services.AddSingleton<ITextLoader, WeatherTextLoader>();
            services.AddSingleton<ITextLoader, WeatherImageLoader>();
            services.AddSingleton<IModel, Model>();


            return services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceCollection services = ConfigureServices();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            ViewModel viewModel = serviceProvider.GetService<ViewModel>();
            base.OnStartup(e);
        }
    }

}
