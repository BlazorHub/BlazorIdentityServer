# Blazor320WasmHostedPwaOidc
A simple Blazor WebAssembly use AddOidcAuthentication() to call secured WebApis

### 0.Oidc Server (eg. IdentityServer4 with abp)
* https://localhost:44387

### 1.Client (ie. this repo)
* https://localhost:5001
```

ClientId = "AbpBlazorApp.Client",
ClientName = "OurAuth Demo Oidc (Local/Development)",
ClientUri = "https://localhost:44387",

AllowedGrantTypes = GrantTypes.Implicit,
AllowAccessTokensViaBrowser = true,
RequireClientSecret = false,

RedirectUris = { "https://localhost:44367/authentication/login-callback" },
PostLogoutRedirectUris = { "https://localhost:44367/authentication/logout-callback" },
AllowedCorsOrigins = { "https://localhost:44387" },

AllowedScopes = {
    IdentityServerConstants.StandardScopes.OpenId,
    IdentityServerConstants.StandardScopes.Profile,
    IdentityServerConstants.StandardScopes.Email,
    IdentityServerConstants.StandardScopes.Phone,
    "AbpBlazorApp.ServerAPI",
 }
```

