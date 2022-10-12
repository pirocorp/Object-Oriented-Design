namespace CachedRepository.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CachedRepository.Data.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Generic Repository Implementation
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public class EfRepository<T>: IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext DbContext;

        public EfRepository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public virtual async Task<T?> GetById(int id)
            => await this.DbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);

        public virtual async Task<IEnumerable<T>> List()
            => await this.DbContext.Set<T>().ToListAsync();

        public async Task<T> Add(T entity)
        {
            await this.DbContext.Set<T>().AddAsync(entity);
            await this.DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Update(T entity)
        {
            this.DbContext.Entry(entity).State = EntityState.Modified;
            await this.DbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
            await this.DbContext.SaveChangesAsync();
        }
    }
}
