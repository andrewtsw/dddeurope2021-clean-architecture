using DddEurope2021.BackgroundJobs.Interfaces;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DddEurope2021.BackgroundJobs.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBackgroundJobService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(options => options
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("Hangfire")));

            services.AddHangfireServer();

            services.AddScoped<IBackgroundJobService, BackgroundJobService>();

            return services;
        }
    }
}
