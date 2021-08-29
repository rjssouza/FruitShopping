using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Security.Configuration
{
    internal static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("FruitApi")
                {
                    Scopes = new string[]{"FruitApi.full_access"}
                }
            };
        public static IEnumerable<ApiScope> ApiScope =>
            new ApiScope[]
            {
                new ApiScope("FruitApi.full_access")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "angularUI",
                    ClientName = "Interface cliente angular",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    //ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0OptionsReport_Mobile_Dasa_Test_Dev".Sha256()) },
                    IdentityProviderRestrictions = new List<string> { null },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "FruitApi.full_access"
                    },
                    RedirectUris = {$"http://localhost:4200/shop"},
                    PostLogoutRedirectUris = {$"http://localhost:4200/"},
                    AllowedCorsOrigins = {$"http://localhost:4200"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,
                    RequireConsent = false
                }
            };

        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
    }
}