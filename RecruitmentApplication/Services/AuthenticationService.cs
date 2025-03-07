using RecruitmentApplication.Models;
using RecruitmentApplication.Repositories;

namespace RecruitmentApplication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }

        public bool IsUserInRole(User user, string roleName)
        {
            if (user == null || user.Role == null)
            {
                return false;
            }
            return user.Role.Name == roleName;
        }
    }
}
