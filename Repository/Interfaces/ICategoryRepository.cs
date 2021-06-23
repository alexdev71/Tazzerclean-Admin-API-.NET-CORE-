using DataContracts.Entities;
using DataContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<List<CategoryNavigationVM>> GeAllForMenuAsync();
        Task<List<CategoryType>> FindByNameAsync(string name);
        Task<Category> AddAsync(Category category);
        Task<List<Category>> GetByIdAsync(Guid id);
        Task<Category> DeleteCategoryType(string id);
        Task<List<Category>> GetByNameAsync(string name);
    }
}
