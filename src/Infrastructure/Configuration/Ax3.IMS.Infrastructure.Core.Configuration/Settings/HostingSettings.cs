namespace Ax3.IMS.Infrastructure.Configuration.Settings
{
    public sealed class HostingSettings
    {
        public string Url { get; set; }
        public bool SwaggerEnabled { get; set; } = true;
        public bool HttpsRequired { get; set; } = false;
        public bool AuthenticationRequired { get; set; } = false;
        public bool ShowErrorDetails { get; set; } = true;
        public bool IsGateway { get; set; } = false;
        public string AuthorityUrl { get; set; }
        public string ScopeName { get; set; }
        public string ClientId { get; set; }
    }
}