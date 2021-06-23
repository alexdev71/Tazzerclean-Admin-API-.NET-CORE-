using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using ServiceContracts.Common;
using System;
using System.Threading.Tasks;

namespace ServiceContracts.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommonRepository _commonRepository;
        private readonly IPasswordHasher _hasher;
        public AuthManager(IAuthRepository authRepository,IUserRepository userRepository,ICommonRepository commonRepository,IPasswordHasher hasher)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _commonRepository = commonRepository;
            _hasher = hasher;
        }

        public async Task<Guid> RegisterAsync(User user,int role)
        { 
            var desiredRole = await _commonRepository.FindRoleByName(Enum.GetName(typeof(RoleType), role));

            user.Id = Guid.NewGuid();

            user.RoleId = desiredRole.Id;

            if (!string.IsNullOrEmpty(user.Password))
            {
                var hashed = _hasher.Hash(user.Password);
                user.Password = hashed.hashed;
                user.Salt = hashed.salt;
            }

            var result = await _authRepository.RegisterAsync(user);

            return result.Id;
        }

        public async Task ChangePasswordAsync(User user)
        {
            if (!string.IsNullOrEmpty(user.Password))
            {
                var hashed = _hasher.Hash(user.Password);
                user.Password = hashed.hashed;
                user.Salt = hashed.salt;
            }

            await _authRepository.ChangePasswordAsync(user);

        }

        public async Task<User> ForgotPasswordCode(Guid id,string code)
        {
            return await _authRepository.ForgotPasswordCodeAsync(id,code);
        }

        public async Task<User> GoogleLogin()
        {
            return await _authRepository.GoogleLoginAsync();
        }

        public async Task RegisterProfessional(CustomerRequest user)
        {
            await _authRepository.RegisterProfessional(user);
        }
    }
}
