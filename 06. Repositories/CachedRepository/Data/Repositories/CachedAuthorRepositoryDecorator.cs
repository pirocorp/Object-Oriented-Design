namespace CachedRepository.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CachedRepository.Data.Models;

    using Microsoft.Extensions.Caching.Memory;

    using static CachedRepository.Infrastructure.GlobalConstants;

    public class CachedAuthorRepositoryDecorator : IReadOnlyRepository<Author>
    {
        private const string AuthorModelCacheKey = "Authors";

        private readonly AuthorRepository repository;
        private readonly IMemoryCache cache;
        private readonly MemoryCacheEntryOptions cacheOptions;

        public CachedAuthorRepositoryDecorator(
            AuthorRepository repository,
            IMemoryCache cache)
        {
            this.repository = repository;
            this.cache = cache;

            this.cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(DEFAULT_CACHE_SECONDS));
        }

        public async Task<Author?> GetById(int id)
            => await this.cache
                .GetOrCreateAsync(
                    $"{AuthorModelCacheKey}-{id}",
                    async entry =>
                    {
                        entry.SetOptions(cacheOptions);
                        return await this.repository.GetById(id);
                    });

        public async Task<IEnumerable<Author>> List()
            => await this.cache
                .GetOrCreateAsync(
                    AuthorModelCacheKey,
                    async entry =>
                    {
                        entry.SetOptions(cacheOptions);
                        return await this.repository.List();
                    });
    }
}
