using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<PostalLookup>> GetAllZipCodes();
        Task DeleteZipCode(Guid id);
        Task AddOrUpdateZipCode(PostalLookup lookup);
        Task<List<CategoryType>> GetAllCategoryType();
        Task DeleteCategoryType(Guid id);
        Task AddOrUpdateCategoryType(CategoryType type);
        Task DeleteCategory(Guid id);
        Task<List<Category>> GetAllCategories();
        Task AddOrUpdateCategory(Category cat);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Partner>> GetAllPartners();
        Task<List<Professional>> GetAllProfessionals();
        Task<List<CategoryType>> GetAllCategorySubType();
        Task DeleteCategorySubType(Guid id);
        Task AddOrUpdateCategorySubType(CategoryType type);
        Task<List<CategoryType>> GetByTypeId(Guid id);
        Task DeleteProfessional(Guid id);
        Task ActiveProfessional(Guid id);
        Task DectiveProfessional(Guid id);
        Task DeleteCustomer(Guid id);
        Task ActiveCustomer(Guid id);
        Task DeactiveCustomer(Guid id);
        Task DeletePartner(Guid id);
        Task ActivePartner(Guid id);
        Task DeactivePartner(Guid id);
    }
}
