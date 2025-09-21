using Microsoft.AspNetCore.Authorization;

namespace Extensions.Authorization.Requirement
{
    public class RolePermissionRequirement : IAuthorizationRequirement
    {
        public Dictionary<string, string> PermissionRequirements { get; set; } = new Dictionary<string, string>();

        public RolePermissionRequirement() { }

        public RolePermissionRequirement(Dictionary<string, string> PermissionRequirements)
        {
            this.PermissionRequirements = PermissionRequirements;
        }
    }
}
