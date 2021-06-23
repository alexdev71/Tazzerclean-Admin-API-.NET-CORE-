using Dapper;
using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<User> FindByName(string username)
        {
            var procedure = "spUsers_Get_ByName";

            var result = await _connection.QueryMultipleAsync(
                    procedure,
                    new { username },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var user = (await result.ReadAsync<User>()).FirstOrDefault();
            var role = (await result.ReadAsync<Role>()).FirstOrDefault();
            var customer = (await result.ReadAsync<Customer>()).FirstOrDefault();
            var address = (await result.ReadAsync<Address>()).FirstOrDefault();

            if (user != null)
            {
                user.Role = new Role();
                user.Role.Name = role.Name;

                user.Customer = new Customer();
                user.Customer = customer;
                user.Address = new Address();
                user.Address = address ?? new Address();
            }


            return user;
        }

        public async Task UpdateProfile(User user)
        {
            var procedure = "spUsers_UpdateProfile";

            await _connection.ExecuteAsync(
                                procedure,
                                new { user.Customer.Firstname, user.Customer.Lastname, user.Customer.Phone, user.Customer.Mobile, user.Customer.Email, user.Customer.Facebook, user.Customer.Website, user.Customer.Linkedin, user.Address.Suburb, user.Address.City, user.Address.Country, user.Address.StreetName, user.Address.HouseNumber,user.Address.ZipCode, user.Id,user.Customer.Middlename },
                                commandType: CommandType.StoredProcedure,
                                commandTimeout: 10
                            );
        }

        public async Task UpdateUserProfileImage(string url,string username)
        {
            var procedure = "spUsers_UpdateProfileImage";

            await _connection.ExecuteAsync(
                                procedure,
                                new { url,username },
                                commandType: CommandType.StoredProcedure,
                                commandTimeout: 10
                            );
        }

        public async Task AddUserServices(Guid userId, Guid serviceId)
        {
            var procedure = "spUser_Add_Services";

            await _connection.ExecuteAsync(
                                procedure,
                                new { userId, serviceId },
                                commandType: CommandType.StoredProcedure,
                                commandTimeout: 10
                            );
        }
    }
}
