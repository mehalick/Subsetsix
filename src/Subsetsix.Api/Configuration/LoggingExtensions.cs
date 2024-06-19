using Serilog;
using Serilog.Events;

namespace Subsetsix.Api.Configuration;

public static class LoggingExtensions
{
    public static LoggerConfiguration AddDefaultLogging(this LoggerConfiguration configuration)
    {
        configuration
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
            .MinimumLevel.Override("System.Net.Http", LogEventLevel.Warning)
            .Enrich.WithProperty("SourceLogger", "Serilog")
            .Enrich.FromLogContext()
            .WriteTo.Console();

        var datadogApiKey = Environment.GetEnvironmentVariable("Datadog:ApiKey");

        if (string.IsNullOrWhiteSpace(datadogApiKey))
        {
            return configuration;
        }

        var datadogSource = Environment.GetEnvironmentVariable("Datadog:Source") ?? throw new ApplicationException("Missing environment variable 'Datadog:Source'.");
        var datadogService = Environment.GetEnvironmentVariable("Datadog:Service") ?? throw new ApplicationException("Missing environment variable 'Datadog:Service'.");
        var datadogHost = Environment.GetEnvironmentVariable("Datadog:Host") ?? throw new ApplicationException("Missing environment variable 'Datadog:Host'.");

        configuration.WriteTo.DatadogLogs(datadogApiKey, datadogSource, datadogService, datadogHost);

        return configuration;
    }
}