using Ax3.IMS.Infrastructure.Configuration.Settings;
using Serilog;
using Serilog.Core;
using System;
using LogEventLevel = Serilog.Events.LogEventLevel;

namespace Ax3.IMS.Infrastructure.Logging
{
    public static class LogConfig
    {
        private static readonly LoggingLevelSwitch LoggingLevelSwitch;

        static LogConfig()
        {
            LoggingLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Verbose);
        }

        public static ILogger Configure(LoggingSettings settings, params ILogEventEnricher[] enrichers)
        {
            return ConfigureInternal(new LoggerConfiguration(), settings, enrichers);
        }

        public static ILogger Configure(this LoggerConfiguration loggerConfiguration, LoggingSettings settings, params ILogEventEnricher[] enrichers)
        {
            return ConfigureInternal(loggerConfiguration, settings, enrichers);
        }

        public static void SetLoggingLevel(LogEventLevel logLevel)
        {
            LoggingLevelSwitch.MinimumLevel = logLevel;
        }

        private static ILogger ConfigureInternal(LoggerConfiguration loggerConfiguration, LoggingSettings settings, params ILogEventEnricher[] enrichers)
        {
            LoggingLevelSwitch.MinimumLevel =
                settings?.Verbosity == null
                ? LogEventLevel.Verbose
                : (LogEventLevel)Enum.Parse(typeof(Configuration.Settings.LogEventLevel), settings.Verbosity.ToString());

            loggerConfiguration
                .MinimumLevel.ControlledBy(LoggingLevelSwitch)
                .Enrich.WithMachineName();

            if (enrichers != null)
            {
                loggerConfiguration.Enrich.With(enrichers);
            }

            if (settings != null)
            {
                if (!string.IsNullOrWhiteSpace(settings.Environment))
                {
                    loggerConfiguration.Enrich.With(new PropertyEnricher("Environment", settings.Environment));
                }

                if (!string.IsNullOrWhiteSpace(settings.ApplicationName))
                {
                    loggerConfiguration.Enrich.With(new PropertyEnricher("ApplicationName", settings.ApplicationName));
                }

                if (!string.IsNullOrEmpty(settings.SinkUrl))
                {
                    loggerConfiguration.WriteTo.Seq(
                        settings.SinkUrl,
                        apiKey: settings.ApiKey,
                        compact: true,
                        controlLevelSwitch: LoggingLevelSwitch);
                }
            }

            loggerConfiguration.Enrich.FromLogContext();

            var logger = loggerConfiguration.CreateLogger();

            Log.Logger = logger;

            return logger;
        }
    }
}