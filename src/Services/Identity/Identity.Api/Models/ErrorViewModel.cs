using IdentityServer4.Models;

namespace Identity.Api.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public ErrorMessage Error { get; set; }
    }
}