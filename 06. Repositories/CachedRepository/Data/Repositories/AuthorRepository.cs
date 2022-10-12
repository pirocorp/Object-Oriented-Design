namespace CachedRepository.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CachedRepository.Data.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository Per Entity
    /// </summary>
    public class AuthorRepository : EfRepository<Author>
    {
        public AuthorRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Author>> List()
        {
            return await this.DbContext.Authors
                .Include(a => a.Resources)
                .ToListAsync();
        }
    }
}
