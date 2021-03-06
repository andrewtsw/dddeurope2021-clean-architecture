﻿using DddEurope2021.Integration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DddEurope2021.Integration.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOrdersIntegration(this IServiceCollection services)
        {
            services.AddScoped<IOrdersIntegrationService, OrdersIntegrationService>();

            return services;
        }
    }
}
