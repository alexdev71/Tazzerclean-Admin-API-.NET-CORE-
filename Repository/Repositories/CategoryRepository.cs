using Dapper;
using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using DataContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _connection;
        public CategoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return new List<Category>();
        }

        public async Task<List<CategoryNavigationVM>> GeAllForMenuAsync()
        {
            var procedure = "spCategoryType_Get_ForNavigation";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var types = (await query.ReadAsync<CategoryType>()).ToList();
            var categories = (await query.ReadAsync<Category>()).ToList();
            var subTypes = (await query.ReadAsync<CategoryType>()).ToList();

            var result = new List<CategoryNavigationVM>();

            foreach (var c in types)
            {
                var cnv = new CategoryNavigationVM()
                {
                    Name = c.Name,
                    Id = c.Id,
                    IconPath = c.IconPath,
                    Type = Enum.GetName(typeof(MainCategoryType), c.Type),
                    HasSubTypes = c.HasSubTypes
                };
                cnv.Categories = new List<Category>();
                cnv.Categories = categories.Where(x => x.TypeId == cnv.Id).ToList();
                cnv.SubTypes = subTypes.Where(x => x.PrimaryType == cnv.Id).ToList();

                result.Add(cnv);
            }

            return result;
        }

        public async Task<List<CategoryType>> FindByNameAsync(string name)
        {
            var procedure = "spCategoryType_Get_ByName";

            var result = await _connection.QueryMultipleAsync(
                    procedure,
                    new { name },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var categories = (await result.ReadAsync<CategoryType>()).ToList();

            return categories;
        }

        public async Task<Category> AddAsync(Category category)
        {
            return new Category();
        }

        public async Task<List<Category>> GetByIdAsync(Guid id)
        {
            var procedure = "spCategory_GetBy_Id";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var categories = (await query.ReadAsync<Category>()).ToList();


            return categories;
        }

        public async Task<List<Category>> GetByNameAsync(string name)
        {
            var procedure = "spCategory_GetBy_Name";

            var query = await _connection.QueryMultipleAsync(
                    procedure,
                    new { name },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 10
                );

            var categories = (await query.ReadAsync<Category>()).ToList();


            return categories;
        }


        public async Task<Category> DeleteCategoryType(string id)
        {
            return new Category();
        }

    }
}
