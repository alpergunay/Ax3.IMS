using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Identity.Api.Configuration
{
    public static class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("imsapi", "IMS Web Api")
                {
                    Scopes = new List<string>()
                    {
                        "imsapi"
                    }
                }
            };
        }

        // Identity resources are data like user ID, name, or email address of a user
        // see: http://docs.identityserver.io/en/release/configuration/resources.html
        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope(name: "imsapi",   displayName: "Access API Backend")
            };
        }

        public static Dictionary<string, string> GetApiClients(IConfiguration configuration)
        {
            var clientUrls = new Dictionary<string, string>();

            clientUrls.Add("ImsApi", configuration.GetValue<string>("ImsApiClient"));
            clientUrls.Add("Spa", configuration.GetValue<string>("SpaClient"));
            clientUrls.Add("WebSpa", configuration.GetValue<string>("WebSpaClient"));
            return clientUrls;
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl)
        {
            if ((clientsUrl == null) || (clientsUrl.Count == 0))
            {
                throw new ArgumentException($"{nameof(clientsUrl)} is null or empty.", nameof(clientsUrl));
            }

            return new List<Client>
            {
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "IMS SPA OpenId Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientsUrl["Spa"]}/auth/callback" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "imsapi"
                    },
                },
                 new Client
                {
                    ClientId = "web-js",
                    ClientName = "IMS Web SPA OpenId Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientsUrl["WebSpa"]}/auth/callback" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["WebSpa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["WebSpa"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "imsapi"
                    },
                },
                 new Client
                {
                    ClientId = "imsapiswaggerui",
                    ClientName = "API Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = { $"{clientsUrl["ImsApi"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["ImsApi"]}/swagger/" },
                    AllowedScopes =
                    {
                        "imsapi"
                    }
                }
            };
        }
    }
}