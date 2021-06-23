using DataContracts.Entities;
using System;
using System.Threading.Tasks;

namespace ServiceContracts.UserManager
{
    public interface IUserManager
    {
        Task<User> FindByName(string name);
        Task UpdateProfile(User user);
        Task UpdateUserProfileImage(string url,string username);
        Task AddUserServices(Guid userId, Guid serviceId);
    }
}
