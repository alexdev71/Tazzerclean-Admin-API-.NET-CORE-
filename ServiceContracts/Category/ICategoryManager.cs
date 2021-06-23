using DataContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.CategoryManager
{
    public interface ICategoryManager
    {
        Task<List<DataContracts.Entities.Category>> GetAll();
        Task<List<CategoryNavigationVM>> GetAllForMenu();
        Task<List<CategoryTypeVM>> FindByName(string name);
        Task<DataContracts.Entities.Category> AddCategory(DataContracts.Entities.Category category);
        Task<List<DataContracts.Entities.Category>> GetTypeById(Guid id);
        Task<DataContracts.Entities.Category> DeleteCategoryType(string id); 
        Task<List<DataContracts.Entities.Category>> GetByName(string name);
    }
}
