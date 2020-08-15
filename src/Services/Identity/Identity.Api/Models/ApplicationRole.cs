using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Api.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Description { get; set; }
    }
}