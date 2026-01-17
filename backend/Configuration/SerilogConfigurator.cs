using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace backend.Configuration;

public static class SerilogConfigurator
{
    public static void Configure(IConfiguration configuration)
    {
        //  Safe Serilog self-log (never blocks)
        var selfLogPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "serilog-selflog.txt");

        Serilog.Debugging.SelfLog.Enable(msg =>
        {
            File.AppendAllText(selfLogPath, msg);
        });

        var basePath = configuration["Logging:BasePath"];
        if (string.IsNullOrWhiteSpace(basePath))
            throw new Exception("Logging:BasePath is missing");

        Directory.CreateDirectory(Path.Combine(basePath, "General"));
        Directory.CreateDirectory(Path.Combine(basePath, "Error"));
        Directory.CreateDirectory(Path.Combine(basePath, "PostgreSql"));

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)

            // Errors
            .WriteTo.Logger(lc =>
                lc.Filter.ByIncludingOnly(e => e.Level >= LogEventLevel.Error)
                  .WriteTo.Async(a => a.File(
                      Path.Combine(basePath, "Error", "error-.log"),
                      rollingInterval: RollingInterval.Day)))

            // PostgreSQL
            .WriteTo.Logger(lc =>
                lc.Filter.ByIncludingOnly(e =>
                    e.Properties.ContainsKey("SourceContext") &&
                    e.Properties["SourceContext"].ToString() == "\"PostgreSql\"")
                  .WriteTo.Async(a => a.File(
                      Path.Combine(basePath, "PostgreSql", "postgres-.log"),
                      rollingInterval: RollingInterval.Day)))

            // General
            .WriteTo.Async(a => a.File(
                Path.Combine(basePath, "General", "general-.log"),
                rollingInterval: RollingInterval.Day))

            .Enrich.FromLogContext()
            .CreateLogger();
    }
}
