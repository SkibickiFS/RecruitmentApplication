using RecruitmentApplication.Models;

namespace RecruitmentApplication.Services
{
    public interface IPermissionService
    {
        bool HasPermission(User user, string permissionName);
    }
}
