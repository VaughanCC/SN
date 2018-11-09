using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Vcc.Security.IDService
{
    /// <summary>
    /// Provides Clients, Users, and Identity Resources for setting up IdentityServer4
    /// </summary>
    /// <remarks>This is required for IdentityServer4.</remarks>
    public class Config
    {
        /// <summary>
        /// Returns test users who are registered with Identity Provider service
        /// </summary>
        /// <returns></returns>
        /// <remarks>This is for testing purpose. Actual user classes need to be implemented and this method will be modified.</remarks>
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "A665CFDC-A610-4AF1-ACC7-29E635181F61",
                    Username = "Frank",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Frank"),
                        new Claim("family_name", "Underwood")
                    }

                },
                new TestUser
                {
                    SubjectId = "A665CFDC-A610-4AF1-ACC7-29E635181F62",
                    Username = "Claire",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Claire"),
                        new Claim("family_name", "Underwood")
                    }

                }
            };
        }

        /// <summary>
        /// Returns Identity Resources
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        /// <summary>
        /// Returns the api resources that are currently registerd with Identity Provider service
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("Vcc.SocialNet.Api", "Vcc Social Network API")
            };
        }

        /// <summary>
        /// Returns the clients that are currently registered with Identity Provider service
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "Vcc Social Network",
                    ClientId = "Vcc.SocialNet",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44318/sigin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId
                    },
                    // For other grant types such as GrantTypes.Hybrid, GrantTypes.Code, etc.
                    //ClientSecrets =
                    //{
                    //    new Secret("secret".Sha256())
                    //}
                }
            };
        }
    }
}
