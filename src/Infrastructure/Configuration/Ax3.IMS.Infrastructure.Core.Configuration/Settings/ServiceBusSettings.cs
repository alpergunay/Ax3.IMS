namespace Ax3.IMS.Infrastructure.Configuration.Settings
{
    public sealed class ServiceBusSettings
    {
        public string QueueName { get; set; }
        public string RabbitMQUrl { get; set; }
        public string RabbitUsername { get; set; }
        public string RabbitPassword { get; set; }
        public string RetryCount { get; set; }
    }
}