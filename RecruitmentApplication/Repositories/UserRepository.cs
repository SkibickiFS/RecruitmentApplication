using RecruitmentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace RecruitmentApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _genericRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public UserRepository(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                var user = _genericRepository.GetAll(g => g.Role.Permissions).FirstOrDefault(u => u.Username == username);
                Logger.Info("Retrieved user with username: {0}", username);
                return user;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving user with username: {0}", username);
                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                var user = _genericRepository.GetById(id, g => g.Role.Permissions);
                Logger.Info("Retrieved user with ID: {0}", id);
                return user;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error retrieving user with ID: {0}", id);
                throw;
            }
        }

        public void AddUser(User user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _genericRepository.Add(user);
                Logger.Info("Added user with username: {0}", user.Username);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error adding user with username: {0}", user.Username);
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _genericRepository.Update(user);
                Logger.Info("Updated user with username: {0}", user.Username);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error updating user with username: {0}", user.Username);
                throw;
            }
        }

        public void DeleteUser(User user)
        {
            try
            {
                _genericRepository.Delete(user);
                Logger.Info("Deleted user with username: {0}", user.Username);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error deleting user with username: {0}", user.Username);
                throw;
            }
        }


    }

}
