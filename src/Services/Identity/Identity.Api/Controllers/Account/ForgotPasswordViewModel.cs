using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Controllers.Account
{
    public class ForgotPasswordViewModel
    {
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}
