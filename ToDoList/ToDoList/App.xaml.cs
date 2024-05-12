using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using ToDoList.View;
using ToDoList.ViewModel;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost _host;
        public IHostBuilder CreateHostBuilder() =>
             Host.CreateDefaultBuilder()
           .ConfigureAppConfiguration((hostContext, config) =>
           {
               config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
               config.AddEnvironmentVariables();
           })
            .ConfigureServices((hostContext, services) => {
                ConfigureServices(hostContext, services);
            });

        public App()
        {
            _host = CreateHostBuilder()
               .Build();
        }

        private void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            // string connection = hostContext.Configuration.GetConnectionString("AppDbContext");
            // services.AddDbContext<AppDbContext>(options => { options.UseSqlite(connection); });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            using (var scope = _host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            }

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            var mainWindowVM = _host.Services.GetRequiredService<MainWindowViewModel>();

            mainWindow.DataContext = mainWindowVM;
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }
    }

}
