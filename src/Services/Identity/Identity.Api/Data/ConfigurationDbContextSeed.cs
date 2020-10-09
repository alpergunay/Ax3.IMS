using Identity.Api.Configuration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data
{
    public static class ConfigurationDbContextSeed
    {
        public static async Task SeedAsync(ConfigurationDbContext context, IConfiguration configuration)
        {
            //callbacks urls from config:
            var clientUrls = new Dictionary<string, string>();

            clientUrls.Add("ImsApi", configuration.GetValue<string>("ImsApiClient"));
            clientUrls.Add("Spa", configuration.GetValue<string>("SpaClient"));
            clientUrls.Add("WebSpa", configuration.GetValue<string>("WebSpaClient"));

            foreach (var client in Config.GetClients(clientUrls))
            {
                var clientEntity = context.Clients.FirstOrDefault(x => x.ClientId == client.ClientId);
                if (clientEntity == null)
                {
                    context.Clients.Add(client.ToEntity());
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Clients.Any())
            {
                foreach (var client in Config.GetClients(clientUrls))
                {
                    context.Clients.Add(client.ToEntity());
                }
                await context.SaveChangesAsync();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.GetResources())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var api in Config.GetApiResources())
                {
                    context.ApiResources.Add(api.ToEntity());
                }

                await context.SaveChangesAsync();
            }
            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.GetApiScopes())
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }
                await context.SaveChangesAsync();
            }
        }
    }
}