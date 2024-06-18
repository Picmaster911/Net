using MauiPhoneCatalog.Helpers;
using MauiPhoneCatalog.ViewModels;
using MauiPhoneCatalog.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PhoneCatalog.DAL;
using PhoneCatalog.DAL.Entities;


namespace MauiPhoneCatalog
{
    public  static  class MauiProgram
    {

        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.AddCore(builder);
            builder.Services.AddSingleton<MainPageVM>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<AddPhonePageVM>();
            builder.Services.AddTransient<PhoneItemPageVM>();
            builder.Services.AddTransient<PhoneItemPage>();
            builder.Services.AddTransient<CreateCollection>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var host = builder.Build();
            using (var scope = host.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dataContext.Database.EnsureCreated();
            }

            return host;
        }

    }

}
