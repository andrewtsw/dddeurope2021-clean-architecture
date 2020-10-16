using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DddEurope2021.UseCases.CQRS
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCQRSUseCases(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IOrdersService, OrdersService>();

            return services;
        }
    }
}
