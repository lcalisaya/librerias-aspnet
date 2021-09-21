using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hangfire.Intro.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureHangfire(this IServiceCollection services,  
                                            IConfiguration configuration)
        {
            // Add Hangfire services.
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                // It will use SqlServer 
                .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService. Server will be in charge of executing jobs
            services.AddHangfireServer();
        }
    }
}
