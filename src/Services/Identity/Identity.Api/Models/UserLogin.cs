using System;

namespace Identity.Api.Models
{
    public class UserLogin
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoffTime { get; set; }
        public string ClientIp { get; set; }
        public string ApplicationName { get; set; }
        public string Browser { get; set; }
        public string Token { get; set; }
        public LoginStatus StatusId { get; set; }
        public DateTime LastlastTradingTime { get; set; }
    }

    public enum LoginStatus
    {
        Login = 1,
        Logout = 2,
        NewLogin = 3,
    }
}