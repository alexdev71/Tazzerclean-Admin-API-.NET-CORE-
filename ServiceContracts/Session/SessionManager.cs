using DataAccess.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Session
{
    public class SessionManager : ISessionManager
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionManager(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task AddSession(DataContracts.Entities.Session session)
        {
            await _sessionRepository.AddSession(session);
        }
    }
}
