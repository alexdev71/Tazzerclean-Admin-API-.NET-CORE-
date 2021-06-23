using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Session
{
    public interface ISessionManager
    {
        Task AddSession(DataContracts.Entities.Session session);
    }
}
