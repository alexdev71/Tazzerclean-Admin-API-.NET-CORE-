using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Interfaces
{
    public interface ICommonRepository
    {
        Task<List<PostalLookup>> FindSuburbAsync(string code);
        Task<Role> FindRoleByName(string name);
        Task<DashboardStats> GetDashboardStats();
    }
}
