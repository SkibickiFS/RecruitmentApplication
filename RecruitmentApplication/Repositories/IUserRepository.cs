using RecruitmentApplication.Models;
using System.Collections.Generic;

namespace RecruitmentApplication.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
