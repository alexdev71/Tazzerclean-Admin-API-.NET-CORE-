using DataAccess.Database.Interfaces;
using DataContracts.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceContracts.CategoryManager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly string categoryNavigationKey = "categoryNavigation";
        private readonly string categoryFindByName = "categoryFindByName";

        public CategoryManager(ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            _categoryRepository = categoryRepository;
            _memoryCache = memoryCache;
        }

        public async Task<List<DataContracts.Entities.Category>> GetAll()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<List<CategoryNavigationVM>> GetAllForMenu()
        {
            var results = new List<CategoryNavigationVM>();

            if (!_memoryCache.TryGetValue(categoryNavigationKey, out List<CategoryNavigationVM> cacheResult))
            {
                var query = await _categoryRepository.GeAllForMenuAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(24));

                // Save data in cache.
                _memoryCache.Set(categoryNavigationKey, query, cacheEntryOptions);

                results = query;
            }
            else
            {
                results = cacheResult;
            }

            return results;
        }

        public async Task<List<CategoryTypeVM>> FindByName(string name)
        {
            var results = new List<CategoryTypeVM>();

            if (!_memoryCache.TryGetValue(categoryFindByName + $"{name}", out List<CategoryTypeVM> cacheResult))
            {
                var query = await _categoryRepository.FindByNameAsync(name);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));

                // Save data in cache.
                _memoryCache.Set(categoryNavigationKey + $"{name}", query, cacheEntryOptions);

                results = cacheResult;
            }
            else
            {
                results = cacheResult;
            }

            foreach (var c in results)
            {
                var cnv = new CategoryTypeVM()
                {
                    Name = c.Name,
                    Id = c.Id.ToString()
                };

                results.Add(cnv);
            }

            return results;
        }

        public async Task<DataContracts.Entities.Category> AddCategory(DataContracts.Entities.Category category)
        {
            _memoryCache.Remove(categoryNavigationKey);
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<List<DataContracts.Entities.Category>> GetTypeById(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<DataContracts.Entities.Category> DeleteCategoryType(string id)
        {
            _memoryCache.Remove(categoryNavigationKey);
            return await _categoryRepository.DeleteCategoryType(id);
        }

        public async Task<List<DataContracts.Entities.Category>> GetByName(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }


    }
}
