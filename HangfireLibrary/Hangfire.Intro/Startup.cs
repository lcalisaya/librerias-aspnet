using Hangfire.Intro.Extensions;
using Hangfire.Intro.Interfaces;
using Hangfire.Intro.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Hangfire.Intro
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
            services.AddControllersWithViews();
            services.ConfigureHangfire(Configuration);
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();
            services.AddHostedService<IntervalTaskHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env, 
                              IBackgroundJobClient backgroundJobs,
                              IRecurringJobManager recurringJobManager,
                              IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHangfireDashboard();
            });

            app.UseHangfireDashboard();

            //Immediately executed
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

            //Execution depending a period of time
            backgroundJobs.Schedule(() => Console.WriteLine("Hello with Delay!"), TimeSpan.FromSeconds(30.0d));

            //Recurring execution task is defined
            recurringJobManager.AddOrUpdate("This will run every minute!", 
                                            () => Console.WriteLine("This is a recurring job"),
                                            Cron.Minutely);

            //It will execute recurring task of Wheather Forecast
            var weatherForecastService = serviceProvider.GetRequiredService<IWeatherForecastService>();   
            recurringJobManager.AddOrUpdate("Wheather Forecast",
                                            () => weatherForecastService.Get(),
                                            Cron.Minutely);

        }
    }
}
