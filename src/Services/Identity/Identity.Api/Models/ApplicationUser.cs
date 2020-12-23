using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string MobilePhoneNumber { get; set; }
        public Guid? LanguageId { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}