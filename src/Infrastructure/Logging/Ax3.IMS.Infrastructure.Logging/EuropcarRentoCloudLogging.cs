using Microsoft.Extensions.Logging;

namespace Ax3.IMS.Infrastructure.Logging
{
    public class ImsLogging
    {
        public static ILoggerFactory LoggerFactory { get; internal set; }

        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();

        public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}