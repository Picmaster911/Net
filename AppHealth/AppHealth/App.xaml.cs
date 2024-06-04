using AppHealth.Model;
using AppHealth.View;
using AppHealth.ViewModel;
using Contracts;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQLitePCL;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace AppHealth
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string projectRootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        private readonly IHost _host;
        public IHostBuilder CreateHostBuilder() =>
             Host.CreateDefaultBuilder()
           .ConfigureAppConfiguration((hostContext, config) =>
           {
               config.SetBasePath(projectRootPath);
               config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
               config.AddEnvironmentVariables();
           })
            .ConfigureServices((hostContext, services) => {
                ConfigureServices(hostContext, services);
            });

        public App()
        {
            Batteries.Init();
            _host = CreateHostBuilder()
               .Build();
        }

        private void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            string connection = hostContext.Configuration.GetConnectionString("AppDbContext");

            services.AddDbContext<IApplicationDbContext,AppDbContext>(options => { options.UseSqlite(connection); });

            services.AddSingleton<CreateGlobalDO>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<AddSettingWindowViewModel>();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            using (var scope = _host.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dataContext.Database.EnsureCreated();
            }

            using (var scope = _host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            }
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();

            var createGlobalDO = _host.Services.GetRequiredService<CreateGlobalDO>();
            createGlobalDO.CreatePersonItemVM();    
            var mainWindowVM = _host.Services.GetRequiredService<MainWindowViewModel>();
            var timerCheckEvent = new TimerCheckEvent(_host.Services);

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
