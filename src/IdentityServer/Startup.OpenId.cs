using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;

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
            services.AddOpenIddict();
        }
    }
}
