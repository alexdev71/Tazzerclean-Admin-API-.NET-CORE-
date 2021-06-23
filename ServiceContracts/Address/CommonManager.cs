using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Common
{
    public class CommonManager : ICommonManager
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly string suburbByCode = "suburbByCode";

        public CommonManager(ICommonRepository commonRepository,IMemoryCache memoryCache)
        {
            _commonRepository = commonRepository;
            _memoryCache = memoryCache;
        }

        public async Task<List<PostalLookup>> FindSuburb(string code)
        {
            var query = new List<PostalLookup>();

            if (!_memoryCache.TryGetValue(suburbByCode + $"{code}", out List<PostalLookup> cacheResult))
            {
                query = await _commonRepository.FindSuburbAsync(code);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));

                // Save data in cache.
                _memoryCache.Set(suburbByCode + $"{code}", query, cacheEntryOptions);
                query = cacheResult;
            }
            else
            {
                query = cacheResult;
            }


            return query;
        }

        public async Task<DashboardStats> GetDashboardStats()
        {
            return await _commonRepository.GetDashboardStats();
        }
    }
}
