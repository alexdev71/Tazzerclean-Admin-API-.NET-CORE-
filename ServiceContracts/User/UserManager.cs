using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _memoryCache;

        public UserManager(IUserRepository userRepository, IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _memoryCache = memoryCache;
        }

        public async Task<User> FindByName(string name)
        {
            var result = await _userRepository.FindByName(name);
            return result;
        }

        public async Task UpdateProfile(User user)
        {
            await _userRepository.UpdateProfile(user);
        }

        public async Task UpdateUserProfileImage(string url,string username)
        {
            await _userRepository.UpdateUserProfileImage(url,username);
        }

        public async Task AddUserServices(Guid userId, Guid serviceId)
        {
            await _userRepository.AddUserServices(userId, serviceId);
        }
    }
}
