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

                    AllowedScopes={"OrderApi"},
                    AllowedGrantTypes=GrantTypes.ClientCredentials
                }
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("OrdersApi")
            };


        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId()
               
            };

    }
}
