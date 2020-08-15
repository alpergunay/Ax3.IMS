using Identity.Api.Data;
using Identity.Api.Models;
using IdentityModel;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Api.Services
{
    public class JweTokenCreationService : DefaultTokenCreationService
    {
        private readonly ApplicationDbContext _context;

        public JweTokenCreationService(ISystemClock clock,
                                       IKeyMaterialService keys,
                                       ILogger<DefaultTokenCreationService> logger,
                                       IdentityServerOptions identityServerOptions, ApplicationDbContext context) : base(clock,
                                                                                           keys,
                                                                                           identityServerOptions,
                                                                                           logger)
        {
            _context = context;
        }

        public override async Task<string> CreateTokenAsync(Token token)
        {
            var loginId = LoginSave(token);
            token.Claims.Add(new Claim("loginId", loginId.ToString()));

            string _token = await base.CreateTokenAsync(token);

            TokenSave(loginId, _token);

            return _token;
        }

        private Guid LoginSave(Token token)
        {
            var userId = Guid.Parse(token.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject).Value);

            UserLogin _oldLogin = _context.UserLogins.FirstOrDefault(x => x.UserId == userId && x.StatusId == LoginStatus.Login);

            if (_oldLogin != null && _oldLogin.StatusId == LoginStatus.Login)
            {
                _oldLogin.StatusId = LoginStatus.NewLogin;
                _oldLogin.LogoffTime = DateTime.Now;
                _context.SaveChanges();
            }

            UserLogin userLogin = new UserLogin()
            {
                LoginTime = DateTime.Now,
                LastlastTradingTime = DateTime.Now,
                UserId = userId,
                StatusId = LoginStatus.Login,
                ClientIp = token.ClientId,
                ApplicationName = token.Audiences.Join(",")
            };

            _context.UserLogins.Add(userLogin);
            _context.SaveChanges();

            return userLogin.Id;
        }

        private void TokenSave(Guid loginId, string token)
        {
            var userLogin = _context.UserLogins.FirstOrDefault(x => x.Id == loginId);
            userLogin.Token = token;
            _context.SaveChanges();
        }
    }
}