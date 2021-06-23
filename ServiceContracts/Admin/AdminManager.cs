using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Admin
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository _adminRepository;


        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;

        }

        public async Task<List<PostalLookup>> GetAllZipCodes()
        {
            return await _adminRepository.GetAllZipCodes();
        }

        public async Task DeleteZipCode(Guid id)
        {
            await _adminRepository.DeleteZipCode(id);
        }

        public async Task AddOrUpdateZipCode(PostalLookup lookup)
        {
            await _adminRepository.AddOrUpdateZipCode(lookup);
        }

        public async Task<List<CategoryType>> GetAllCategoryType()
        {
            return await _adminRepository.GetAllCategoryType();
        }

        public async Task DeleteCategoryType(Guid id)
        {
            await _adminRepository.DeleteCategoryType(id);
        }

        public async Task AddOrUpdateCategoryType(CategoryType lookup)
        {
            await _adminRepository.AddOrUpdateCategoryType(lookup);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _adminRepository.GetAllCategories();
        }

        public async Task DeleteCategory(Guid id)
        {
            await _adminRepository.DeleteCategory(id);
        }
        public async Task AddOrUpdateCategory(Category cat)
        {
            await _adminRepository.AddOrUpdateCategory(cat);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _adminRepository.GetAllCustomers();
        }

        public async Task<List<Professional>> GetAllProfessionals()
        {
            return await _adminRepository.GetAllProfessionals();
        }

        public async Task<List<Partner>> GetAllPartners()
        {
            return await _adminRepository.GetAllPartners();
        }

        public async Task<List<CategoryType>> GetAllCategorySubType()
        {
            return await _adminRepository.GetAllCategorySubType();
        }

        public async Task DeleteCategorySubType(Guid id)
        {
            await _adminRepository.DeleteCategorySubType(id);
        }

        public async Task AddOrUpdateCategorySubType(CategoryType lookup)
        {
            await _adminRepository.AddOrUpdateCategorySubType(lookup);
        }

        public async Task<List<CategoryType>> GetByTypeId(Guid id)
        {
            return await _adminRepository.GetByTypeId(id);
        }

        public async Task DeleteProfessional(Guid id)
        {
            await _adminRepository.DeleteProfessional(id);
        }

        public async Task ActiveProfessional(Guid id)
        {
            await _adminRepository.ActiveProfessional(id);
        }

        public async Task DeactiveProfessional(Guid id)
        {
            await _adminRepository.DectiveProfessional(id);
        }

        public async Task DeleteCustomer(Guid id)
        {
            await _adminRepository.DeleteCustomer(id);
        }

        public async Task ActiveCustomer(Guid id)
        {
            await _adminRepository.ActiveCustomer(id);
        }

        public async Task DeactiveCustomer(Guid id)
        {
            await _adminRepository.DeactiveCustomer(id);
        }

        public async Task DeletePartner(Guid id)
        {
            await _adminRepository.DeletePartner(id); ;
        }

        public async Task ActivePartner(Guid id)
        {
            await _adminRepository.ActivePartner(id);
        }

        public async Task DeactivePartner(Guid id)
        {
            await _adminRepository.DeactivePartner(id);
        }
    }
}
