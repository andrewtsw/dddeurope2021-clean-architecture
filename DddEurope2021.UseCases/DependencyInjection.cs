using Microsoft.Extensions.DependencyInjection;

namespace DddEurope2021.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IOrdersService, OrdersService>();

            return services;
        }
    }
}
