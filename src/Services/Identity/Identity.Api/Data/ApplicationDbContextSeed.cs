using Ax3.IMS.Infrastructure.Core.Permissions;
using Identity.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Npgsql;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data
{
    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env,
            ILogger<ApplicationDbContextSeed> logger, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var policy = CreatePolicy(logger, nameof(ApplicationDbContextSeed));
            try
            {
                var contentRootPath = env.ContentRootPath;
                var webroot = env.WebRootPath;

                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetDefaultUser());

                    await context.SaveChangesAsync();
                }

                var user = await userManager.FindByEmailAsync("alpergunay@gmail.com");
                var role = new ApplicationRole("Admin", "Tam yetkili");

                if (!userManager.GetRolesAsync(user).Result.Any(x => x == role.Name))
                {
                    var result = await roleManager.CreateAsync(role);
                    userManager.AddToRoleAsync(user, role.Name).Wait();
                }

                role = await roleManager.FindByNameAsync(role.Name);

                foreach (var permission in Permissions.GetPermitionList())
                {
                    if (!roleManager.GetClaimsAsync(role).Result.Any(x => x.Value == permission))
                    {
                        await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(Permissions.ClaimType, permission));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(ApplicationDbContext));
            }
        }

        private IEnumerable<ApplicationUser> GetDefaultUser()
        {
            var user = new ApplicationUser()
            {
                Email = "alpergunay@gmail.com",
                Id = Guid.NewGuid(),
                Surname = "Günay",
                Name = "Alper",
                PhoneNumber = "5382588142",
                MobilePhoneNumber = "5382588142",
                UserName = "alpergunay",
                NormalizedEmail = "ALPERGUNAY@GMAIL.COM",
                NormalizedUserName = "ALPERGUNAY",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "123");

            return new List<ApplicationUser>()
            {
                user
            };
        }

        private static AsyncPolicy CreatePolicy(ILogger<ApplicationDbContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<NpgsqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }
    }
}