using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Service;

namespace WebApi_CQRS.Modules
{
    public static class CoreModules
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
               .FromAssembliesOf(typeof(IRequestHandler<>))
               .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                   .AsImplementedInterfaces()
                   .WithTransientLifetime()
               .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>)))
                   .AsImplementedInterfaces()
                   .WithTransientLifetime());

            services.AddDbContext<ShopContext>(options =>
            {               
                options.UseSqlServer(configuration.GetConnectionString("ProductManager"));
            });

            return services;
        }
    }
}
