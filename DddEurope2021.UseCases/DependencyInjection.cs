﻿using DddEurope2021.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DddEurope2021.UseCases.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IOrdersService1, OrdersService1>();

            return services;
        }
    }
}
