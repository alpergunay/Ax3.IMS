﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ims.Api.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserIdentity()
        {
            return _context.HttpContext.User.FindFirst("sub").Value;
        }

        public string GetUserName()
        {
            return _context.HttpContext.User.Identity.Name;
        }
    }
}
