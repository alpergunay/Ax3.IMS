namespace Ax3.IMS.Infrastructure.Configuration.Settings
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            Hosting = new HostingSettings();
            ServiceBus = new ServiceBusSettings();
            InteropServiceBus = new ServiceBusSettings();
            Logging = new LoggingSettings();
            Persistence = new PersistenceSettings();
        }

        public HostingSettings Hosting { get; set; }

        public ServiceBusSettings ServiceBus { get; set; }

        public ServiceBusSettings InteropServiceBus { get; set; }

        public LoggingSettings Logging { get; set; }

        public PersistenceSettings Persistence { get; set; }
        public CacheSettings Cache { get; set; }

        public int TokenLifetimeMinutes { get; set; }
        public int PermanentTokenLifetimeDays { get; set; }
        public bool UseCustomizationData { get; set; }
        public string SubscriptionClientName { get; set; }
        public string SecretKey { get; set; }
    }
}