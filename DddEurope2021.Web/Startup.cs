using DddEurope2021.BackgroundJobs.Implementation;
using DddEurope2021.DataAccess.Sqlite;
using DddEurope2021.DataAccess.SqlServer;
using DddEurope2021.Integration.Implementation;
using DddEurope2021.UseCases.CQRS;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DddEurope2021.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDataAccessSqlServer(Configuration);
            services.AddDataAccessSqlite(Configuration);
            services.AddCQRSUseCases();
            services.AddOrdersIntegration();

            services.AddBackgroundJobService(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseHangfireDashboard();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
