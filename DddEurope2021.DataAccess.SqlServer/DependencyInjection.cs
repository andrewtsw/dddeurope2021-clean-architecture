using DddEurope2021.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DddEurope2021.DataAccess.SqlServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<SqlServerDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DddEurope2021_SqlServer")))
                .AddScoped<IDbContext>(provider => provider
                    .GetService<SqlServerDbContext>());

            return services;
        }
    }
}
