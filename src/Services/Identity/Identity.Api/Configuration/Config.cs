using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Identity.Api.Configuration
{
    public static class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("imsapi", "IMS API Service"),
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