using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Common
{
    public interface ICommonManager
    {
        Task<List<PostalLookup>> FindSuburb(string code);
        Task<DashboardStats> GetDashboardStats();
    }
}
