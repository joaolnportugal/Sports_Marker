using Microsoft.EntityFrameworkCore;
using Sports_Marker.Business.Services;
using Sports_Marker.Data;
using Sports_Marker.Data.Models.GenericRepo;

namespace Sports_Marker.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SMDbContext>(opts =>
            {
                var connectionString = configuration.GetConnectionString("Default");
                var migrationsAssembly = typeof(SMDbContext).Assembly.GetName().Name;

                opts.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                    sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(15), null);
                });
            });
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<ISMService, SMService>();


            return services;
        }
    }
}
