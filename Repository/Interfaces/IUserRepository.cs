using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByName(string username);
        Task UpdateProfile(User user);
        Task UpdateUserProfileImage(string url,string username);
        Task AddUserServices(Guid userId, Guid serviceId);
    }
}
