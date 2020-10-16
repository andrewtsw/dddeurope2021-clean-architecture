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
                .AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DddEurope2021_CleanArchitecture")));

            return services;
        }
    }
}
