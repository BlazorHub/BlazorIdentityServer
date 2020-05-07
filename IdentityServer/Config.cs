// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
            new[]
            {
                new ApiResource("BlazorApp1.ServerAPI", "My Demo Api")
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "BlazorApp1.Client",
                    AllowedGrantTypes = GrantTypes.Code,

                    ClientSecrets =
                    {
                        new Secret("".Sha256())
                    },

                    RequirePkce = true,
                    RequireClientSecret = false,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "BlazorApp1.ServerAPI"
                    },
                    RedirectUris =
                    {
                        "https://localhost:44367/authentication/login-callback"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:44367/authentication/logout-callback"
                    }
                },
            };

    }
}