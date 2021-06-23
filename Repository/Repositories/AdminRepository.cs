using Dapper;
using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IDbConnection _connection;
        public AdminRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        #region zip codes
        public async Task<List<PostalLookup>> GetAllZipCodes ()
        {
            var procedure = "spZipCodes_Get_All";
           
            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 0
                );

            var locations = (await query.ReadAsync<PostalLookup>()).ToList();
            _connection.Close();
            return locations;
        }

        public async Task DeleteZipCode(Guid id)
        {
            var procedure = "spZipCodes_Delete";

            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task AddOrUpdateZipCode(PostalLookup lookup)
        {
            var procedure = "spZipCodes_AddOrUpdate";

            await _connection.ExecuteAsync(
                    procedure,
                    new { lookup.Id,lookup.Suburb,lookup.Country,lookup.Postcode,lookup.Latitude,lookup.Longitude,lookup.Type },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }
        #endregion

        #region categories type
        public async Task<List<CategoryType>> GetAllCategoryType()
        {
            var procedure = "spCategoriesType_GetAll";
            //_connection.Open()
            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var types = (await query.ReadAsync<CategoryType>()).ToList();
           // _connection.Close();
            return types;
        }

        public async Task DeleteCategoryType(Guid id)
        {
            var procedure = "spCategoriesType_Delete";
            //_connection.Open();
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
            //_connection.Close();
        }

        public async Task AddOrUpdateCategoryType(CategoryType type)
        {
            var procedure = "spCategoriesType_AddOrUpdate";
            //_connection.Open();
            await _connection.ExecuteAsync(
                    procedure,
                    new { type.Id, type.Name,type.Description,type.Deleted,type.IconPath, type.TypeOrder, type.CatCode },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
            //_connection.Close();
        }
        #endregion

        #region categories
        public async Task<List<Category>> GetAllCategories()
        {
            var procedure = "spCategory_GetAll";
           // _connection.Open();

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var categories = (await query.ReadAsync<Category>()).ToList();
           // _connection.Close();
            return categories;
        }

        public async Task DeleteCategory(Guid id)
        {
            var procedure = "spCategory_Delete";

            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task AddOrUpdateCategory(Category cat)
        {
            var procedure = "spCategory_AddOrUpdate";

            await _connection.ExecuteAsync(
                    procedure,
                    new { cat.Id,cat.Name,cat.Description,cat.WorkingHours,cat.Price,cat.Deleted,cat.TypeId, cat.SubType,cat.PayPerHour, cat.PayPerSize },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }
        #endregion
        public async Task<List<CategoryType>> GetAllCategorySubType()
        {
            
            var procedure = "spCategoriesSubType_GetAll";
            //_connection.Open();
            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var types = (await query.ReadAsync<CategoryType>()).ToList();
            //_connection.Close();
            return types;
        }

        public async Task DeleteCategorySubType(Guid id)
        {
            var procedure = "spCategoriesSubType_Delete";
            //_connection.Open();
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
            //_connection.Close();
        }

        public async Task AddOrUpdateCategorySubType(CategoryType type)
        {
            var procedure = "spCategoriesSubType_AddOrUpdate";
            //_connection.Open();
            await _connection.ExecuteAsync(
                    procedure,
                    new { type.Id, type.Name, type.Description, type.Deleted, type.PrimaryType, type.SubcatCode },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
            //_connection.Close();
        }

        public async Task<List<CategoryType>> GetByTypeId(Guid id)
        {
            var procedure = "spCategoriesSubType_GetByTypeId";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var types = (await query.ReadAsync<CategoryType>()).ToList();

            return types;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var procedure = "spCustomer_GetAll";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var customer = (await query.ReadAsync<Customer>()).ToList();

            return customer;
        }
        public async Task<List<Partner>> GetAllPartners()
        {
            var procedure = "spPartner_GetAll";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var partner = (await query.ReadAsync<Partner>()).ToList();

            return partner;
        }
        public async Task<List<Professional>> GetAllProfessionals()
        {
            var procedure = "spProfessional_GetAll";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var proff = (await query.ReadAsync<Professional>()).ToList();

            return proff;
        }
        public async Task DeleteProfessional(Guid id)
        {
            var procedure = "spProfessional_Delete";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task ActiveProfessional(Guid id)
        {
            var procedure = "spProfessional_Active";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task DectiveProfessional(Guid id)
        {
            var procedure = "spProfessional_Deactive";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task DeleteCustomer(Guid id)
        {
            var procedure = "spCustomer_Delete";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task ActiveCustomer(Guid id)
        {
            var procedure = "spCustomer_Active";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task DeactiveCustomer(Guid id)
        {
            var procedure = "spCustomer_Deactive";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task DeletePartner(Guid id)
        {
            var procedure = "spPartner  _Delete";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task ActivePartner(Guid id)
        {
            var procedure = "spPartner_Active";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }

        public async Task DeactivePartner(Guid id)
        {
            var procedure = "spPartner_Deactive";
            await _connection.ExecuteAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );
        }
    }
}
