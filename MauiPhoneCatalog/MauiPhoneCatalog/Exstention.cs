using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneCatalog.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiPhoneCatalog
{
    public static class MyExtensions
    {
        public static MauiAppBuilder AddCore (this MauiAppBuilder build, MauiAppBuilder builder)
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MauiPhoneCatalog.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);
            var baseConnectionString = builder.Configuration.GetConnectionString("AppDbContext");
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
            builder.Services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlite(baseConnectionString));
            return builder;
        }
    }
}
