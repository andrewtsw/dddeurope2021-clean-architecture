using DddEurope2021.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DddEurope2021.DataAccess.Sqlite
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<SqliteDbContext>(options => options
                    .UseSqlite(configuration.GetConnectionString("DddEurope2021_Sqlite")))
                .AddScoped<IDbContext>(provider => provider
                    .GetService<SqliteDbContext>());

            return services;
        }
    }
}
