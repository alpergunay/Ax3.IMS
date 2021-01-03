using Serilog.Events;
using System.IO;
using Serilog.Formatting;

namespace PriceProviders.Shared
{
    public class AWSLogTextFormatter : ITextFormatter
    {
        public void Format(LogEvent logEvent, TextWriter output)
        {
            output.Write("Level-{0} | {1} > {2} {3}", logEvent.Level, logEvent.Properties["SourceContext"]?.ToString(), logEvent.MessageTemplate, output.NewLine);
            if (logEvent.Exception != null)
            {
                output.Write("Exception - {0}", logEvent.Exception);
            }
            
        }
    }
}
