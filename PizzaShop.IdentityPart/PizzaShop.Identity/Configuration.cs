using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace PizzaShop.Identity
{
    /// <summary>
    /// This class contains information about clients, resources etc.
    /// </summary>
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("ShopWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("ShopWebApi", "Web API", new [] {JwtClaimTypes.Name})
                {
                    Scopes = { "ShopWebApi" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "shop-web-api",
                    ClientName = "Shop Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris = {"http://.../signin-oidc"},
                    AllowedCorsOrigins = {"http://..."},
                    PostLogoutRedirectUris = {"http:/.../signout-oidc"},
                    AllowedScopes = 
                    {   IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ShopWebApi"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
