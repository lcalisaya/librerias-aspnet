using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

namespace HealthChecks.Intro
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
            services.AddRazorPages();

            services.AddHealthChecks()
                .AddCheck("Service 1", () => 
                    HealthCheckResult.Healthy("Service 1 is working as expected"), new[] { "database"} )
                .AddCheck("Service 2", () =>
                    HealthCheckResult.Unhealthy("Service 2 isn't running!"))
                .AddCheck("Service 3", () =>
                    HealthCheckResult.Degraded("Service 3 is really slow"), new[] { "database", "sqlserver" });

            //Saving the healthchecks in memory
            services.AddHealthChecksUI().AddInMemoryStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI();

                //Healthchecks without details
                endpoints.MapHealthChecks("/healthoverview", new HealthCheckOptions()
                {
                    Predicate = _ => false
                });
                //Healthchecks according specified tags
                endpoints.MapHealthChecks("/health/databases", new HealthCheckOptions()
                {
                    Predicate = serv => serv.Tags.Contains("database"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
