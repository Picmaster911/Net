using CoreReference.Service;
using Microsoft.EntityFrameworkCore;
using DAL.ReferenceMyData.Context;

namespace CoreReferenseMyData.Modules
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

            services.AddDbContext<ReferenceConext>(options =>
            {               
                options.UseSqlServer(configuration.GetConnectionString("CoreEeferenceData"));
            });

            return services;
        }
    }
}
