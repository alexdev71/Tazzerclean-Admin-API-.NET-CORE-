using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Admin
{
    public interface IAdminManager
    {
        Task<List<PostalLookup>> GetAllZipCodes();
        Task DeleteZipCode(Guid id);
        Task AddOrUpdateZipCode(PostalLookup lookup);
        Task<List<CategoryType>> GetAllCategoryType();
        Task DeleteCategoryType(Guid id);
        Task AddOrUpdateCategoryType(CategoryType lookup);
        Task<List<Category>> GetAllCategories();
        Task DeleteCategory(Guid id);
        Task AddOrUpdateCategory(Category cat);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Professional>> GetAllProfessionals();
        Task DeleteProfessional(Guid id);
        Task<List<Partner>> GetAllPartners();
        Task<List<CategoryType>> GetAllCategorySubType();
        Task DeleteCategorySubType(Guid id);
        Task AddOrUpdateCategorySubType(CategoryType lookup);
        Task<List<CategoryType>> GetByTypeId(Guid id);
        Task ActiveProfessional(Guid id);
        Task DeactiveProfessional(Guid id);
        Task DeleteCustomer(Guid id);
        Task ActiveCustomer(Guid id);
        Task DeactiveCustomer(Guid id);
        Task DeletePartner(Guid id);
        Task ActivePartner(Guid id);
        Task DeactivePartner(Guid id);
    }
}
