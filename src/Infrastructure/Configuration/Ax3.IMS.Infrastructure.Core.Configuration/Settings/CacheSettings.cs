namespace Ax3.IMS.Infrastructure.Configuration.Settings
{
    public class CacheSettings
    {
        public string ServerAddress { get; set; }
        public int PortNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Database { get; set; }

        public string GetConnectionString()
        {
            return string.Format("{0}:{1},password={2}", ServerAddress, PortNumber, Password);
        }
    }
}