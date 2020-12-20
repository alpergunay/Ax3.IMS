using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Controllers.Account
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}