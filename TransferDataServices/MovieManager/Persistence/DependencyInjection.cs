﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var t = configuration.GetConnectionString("MovieManager");

            services.AddDbContext<MovieManagerContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MovieManager"),
                    b => b.MigrationsAssembly(typeof(MovieManagerContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<MovieManagerContext>());
        }
    }
}
