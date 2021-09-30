using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HealthChecks.Intro.PersonalizedHealthChecks
{
    public class LatencyHealthCheck : IHealthCheck
    {
        private Random random = new Random();
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
                                                        CancellationToken cancellationToken = default)
        {
            int latency = random.Next(1, 15);

            if (latency < 5)
            {
                return Task.FromResult(HealthCheckResult.Healthy($"Latency is OK: {latency}."));
            } 
            else if (latency < 10)
            {
                return Task.FromResult(HealthCheckResult.Degraded($"Latency is slow. It can be improved: {latency}."));
            } 
            else {
                return Task.FromResult(HealthCheckResult.Unhealthy($"Latency is longer than expected: {latency}."));
            }
        }
    }
}
