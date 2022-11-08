using IdentityServer.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using System;

namespace IdentityServer
{
    public partial class Startup
    {
        public void ConfigureOpenIdDict(IServiceCollection services)
        {
            // Configure the identity system to use the OpenIddict claim types
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIddictConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIddictConstants.Claims.Role;
                // configure more options if necessary...
            });

            // configure the OpenID Connect server
            services.AddOpenIddict()
                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default entities.
                    options.UseEntityFrameworkCore()
                           .UseDbContext<ApplicationDbContext>();
                })
                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the token endpoint.
                    options.SetTokenEndpointUris("/connect/token");
                    options.SetUserinfoEndpointUris("/connect/userinfo");
                    options.AllowPasswordFlow();
                    options.AllowRefreshTokenFlow();
                    // Add all auth flows you want to support
                    // Supported flows are:
                    //      - Authorization code flow
                    //      - Client credentials flow
                    //      - Device code flow
                    //      - Implicit flow
                    //      - Password flow
                    //      - Refresh token flow

                    // Register your scopes - Scopes are a list of identifiers used to specify
                    // what access privileges are requested.
                    options.RegisterScopes(OpenIddictConstants.Permissions.Scopes.Email,
                                    OpenIddictConstants.Permissions.Scopes.Profile,
                                    OpenIddictConstants.Permissions.Scopes.Phone,
                                    OpenIddictConstants.Permissions.Scopes.Address,
                                    OpenIddictConstants.Permissions.Scopes.Roles);

                    // Set the lifetime of your tokens
                    options.SetAccessTokenLifetime(TimeSpan.FromMinutes(30));
                    options.SetRefreshTokenLifetime(TimeSpan.FromDays(7));
                    // Register signing and encryption details
                    options.AddDevelopmentEncryptionCertificate() // Change this on production, see here https://documentation.openiddict.com/configuration/encryption-and-signing-credentials.html
                        .AddDevelopmentSigningCertificate();
                });
        }
    }
}
