using System;
using System.Threading.Tasks;

namespace DataAccess.Database.Interfaces
{
    public interface IAzureRepository
    {
        Task<string> StoreFile(string name, Guid id, byte[] fileContent);
    }
}