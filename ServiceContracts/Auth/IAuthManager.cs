using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Auth
{
    public interface IAuthManager
    {
        Task<Guid> RegisterAsync(User user, int role);
        Task<User> ForgotPasswordCode(Guid id, string code);
        Task<User> GoogleLogin();
        Task ChangePasswordAsync(User user);
        Task RegisterProfessional(CustomerRequest user);
    }
}
