using RecruitmentApplication.Models;

namespace RecruitmentApplication.Services
{
    public interface IAuthenticationService
    {
        User Authenticate(string username, string password);
        bool IsUserInRole(User user, string roleName);
    }
}
