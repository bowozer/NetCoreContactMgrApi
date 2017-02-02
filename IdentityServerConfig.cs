using System.Collections.Generic;
using IdentityServer4.Models;

namespace NetCoreContactMgrApi
{
    /// <summary>
    /// Part of identity server
    /// </summary>
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            var secret = new Secret("contact-mgr-secret".Sha256());
            var client = new Client()
            {
                ClientId = "contact-mgr-client",

                // no interactive user, use clientId/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets = { secret },

                // scopes that client has access to
                AllowedScopes = { "api1" },

                AllowedCorsOrigins = { "http://localhost:9000" }
            };

            return new List<Client>() { client };
        }
    }
}
