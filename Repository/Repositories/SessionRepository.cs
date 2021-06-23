using Dapper;
using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IDbConnection _connection;
        public SessionRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task AddSession(Session session)
        {
            var procedure = "spShoppingSession_AddOrUpdate";

            var query = await _connection.ExecuteAsync(
                procedure,
                new { },
                commandType: CommandType.StoredProcedure,
                commandTimeout: 10
                );
        }
    }
}
