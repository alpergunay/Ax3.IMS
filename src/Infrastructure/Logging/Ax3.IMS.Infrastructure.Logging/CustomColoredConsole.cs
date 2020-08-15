using Ax3.IMS.Infrastructure.Configuration.Settings;
using Serilog;
using Serilog.Configuration;
using System;

namespace Ax3.IMS.Infrastructure.Logging
{
    public static class CustomColoredConsole
    {
        public static Action<LoggingSettings, LoggerSinkConfiguration> SinkConfiguration => (settings, sinkConfiguration) =>
        {
            if (settings.Environment.Equals("Local", StringComparison.InvariantCultureIgnoreCase))
            {
                sinkConfiguration.Console(
                    outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] ({CorrelationId}) {Message}{NewLine}{Exception}");
            }
            else
            {
                sinkConfiguration.Console(
                    outputTemplate: "[{Level}] {Message}{NewLine}");
            }
        };
    }
}