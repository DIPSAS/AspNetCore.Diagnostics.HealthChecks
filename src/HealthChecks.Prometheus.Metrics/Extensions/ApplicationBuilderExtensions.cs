using System;
using HealthChecks.Prometheus.Metrics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class PrometheusHealthCheckMiddleware 
    {
        public static IApplicationBuilder UseHealthChecksPrometheusExporter(this IApplicationBuilder applicationBuilder, PathString endpoint, Action<HealthCheckOptions> setup=null) 
        {
            var opt = new HealthCheckOptions()
            {
                ResponseWriter = PrometheusResponseWriter.WritePrometheusResultText
            };
            setup?.Invoke(opt);

            applicationBuilder.UseHealthChecks(endpoint, opt);
            return applicationBuilder;
        }
    }
}