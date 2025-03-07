using RecruitmentApplication.Models;
using System.Linq;

namespace RecruitmentApplication.Services
{
    public class PermissionService : IPermissionService
    {
        public bool HasPermission(User user, string permissionName)
        {
            if (user == null || string.IsNullOrWhiteSpace(permissionName))
            {
                return false;
            }

            var role = user.Role;
            if (role == null || role.Permissions == null)
            {
                return false;
            }

            return role.Permissions.Any(p => p.Name == permissionName);
        }
    }
}
