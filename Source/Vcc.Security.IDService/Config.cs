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

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        public static List<Client> GetClients()
        {
            return new List<Client>();
        }
    }
}
