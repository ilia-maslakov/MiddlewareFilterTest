using Serilog;
using Serilog.AspNetCore;
using Serilog.Extensions.Hosting;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Compact;

namespace Store.WebAPI.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggerServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Настройка Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console(new CompactJsonFormatter())
                .CreateLogger();

            services.AddSingleton(Log.Logger);
            services.AddSingleton<DiagnosticContext>();

            // Добавление логгера в сервисы
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(dispose: true);
            });

            return services;
        }
    }
}