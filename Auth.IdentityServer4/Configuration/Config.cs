using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Auth.IdentityServer4.Configuration
{
    public static  class Config
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId="client_id",
                    ClientSecrets={new Secret("client_secret".ToSha512())},

                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"OrdersAPI"}
                }
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("OrdersAPI")
            };


        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId()
               
            };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope("OrdersAPI")
            };

    }
}
