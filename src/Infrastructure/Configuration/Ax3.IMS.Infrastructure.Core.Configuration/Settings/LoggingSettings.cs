namespace Ax3.IMS.Infrastructure.Configuration.Settings
{
    public sealed class LoggingSettings
    {
        public LogEventLevel Verbosity { get; set; } = LogEventLevel.Information;
        public string Environment { get; set; }

        public string ApplicationName { get; set; }

        //For writing logs to Seq
        public string SinkUrl { get; set; }

        public string ApiKey { get; set; }
    }
}