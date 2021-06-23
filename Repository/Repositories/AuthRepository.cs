using Dapper;
using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Database.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnection _connection;
        public AuthRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var procedure = "spUser_Register";

            var email = user.Customer.Email.Length == 0 ? user.Username : user.Customer.Email;
            var customerId = user.Customer.Id;
            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { user.Id,user.Username,user.Password,user.Salt,user.RoleId,user.Customer.Firstname,user.Customer.Lastname,email,user.Customer.Phone,customerId,user.PrimaryService,user.Middlename },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var result = (await query.ReadAsync<User>()).FirstOrDefault();

            return result;
        }

        public async Task<User> ForgotPasswordCodeAsync(Guid id, string code)
        {
            var procedure = "spUser_ForgotPassword_Code";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { id, code},
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var result = (await query.ReadAsync<User>()).FirstOrDefault();

            return result;
        }

        public async Task ChangePasswordAsync(User user)
        {
            var procedure = "spUser_ChangePassword";

            var query = await _connection.ExecuteAsync(
                    procedure,
                    new { user.Id, user.Password, user.Salt },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10

                );

        }

        public async Task RegisterProfessional(CustomerRequest user)
        {
            var procedure = "spProfessionalForm_Add";

            var query = await _connection.ExecuteAsync(
                procedure,
                new { user.UserId,user.ProfessionalType,user.PrimaryService,user.AreasAroundPostcode,user.OwnMaterialTools,user.OwnTransport,user.OtherEmployment,user.WillingToTrain,user.Uniform },
                commandType: CommandType.StoredProcedure,
                commandTimeout: 10
                );
        }

        public async Task<User> GoogleLoginAsync()
        {
            return new User();
        }


    }
}
