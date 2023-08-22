using Microsoft.AspNetCore.Authorization;
using X.Yönetim.UI.Models;

namespace X.Yönetim.UI.Authorization
{
    public class RoleAccessRequirement : IAuthorizationRequirement
    {
        public Roles[] Roles { get; set; }

        public RoleAccessRequirement(params Roles[] roles)
        {
            Roles = roles;
        }
    }
}
