
using Microsoft.AspNetCore.Authorization;
using X.Yönetim.UI.Authorization;
using X.Yönetim.UI.Models;

namespace X.Yönetim.UI.Configurations
{
    public static class AuthorizationInjection
    {
        public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, SessionBasedAccessHandler>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Roles.Admin));
                });

                opt.AddPolicy("User", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Roles.User));
                });

                opt.AddPolicy("AdminOrUser", policy =>
                {
                    policy.AddRequirements(new RoleAccessRequirement(Roles.Admin, Roles.User));
                });

            });

            return services;
        }
    }
}
