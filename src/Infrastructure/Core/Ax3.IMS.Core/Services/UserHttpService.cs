using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Ax3.IMS.Infrastructure.Core.Services
{
    public class UserHttpService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserHttpService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetUserId()
        {
            return _httpContext.HttpContext == null ? "admin" : _httpContext.HttpContext.User.FindFirst("sub").Value;
        }

        public string GetUserName()
        {
            return _httpContext.HttpContext == null ? "admin" : _httpContext.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.Name).Value;
        }
    }
}