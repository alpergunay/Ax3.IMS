using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Controllers.Account
{
    public class LoginInputModel
    {
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string Email { get; set; }
    }
}