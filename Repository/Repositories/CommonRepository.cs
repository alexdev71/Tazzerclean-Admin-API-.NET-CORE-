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
    public class CommonRepository : ICommonRepository
    {
        private readonly IDbConnection _connection;
        public CommonRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<PostalLookup>> FindSuburbAsync(string code)
        {
            var procedure = "spSuburb_Get_ByCode";

            var result = await _connection.QueryMultipleAsync(
                    procedure,
                    new { code },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var suburbs = (await result.ReadAsync<PostalLookup>()).ToList();

            return suburbs;
        }

        public async Task<Role> FindRoleByName(string name)
        {
            var procedure = "spRole_Get_ByName";

            var result = await _connection.QueryMultipleAsync(
                    procedure,
                    new { name },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var role = (await result.ReadAsync<Role>()).FirstOrDefault();

            return role;
        }

        public async Task<DashboardStats> GetDashboardStats()
        {
            var procedure = "spDashboard_GetStats";

            var result = await _connection.QueryMultipleAsync(
                    procedure,
                    new {  },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var count = (await result.ReadAsync<DashboardStats>()).FirstOrDefault();

            return count;
        }
    }
}
