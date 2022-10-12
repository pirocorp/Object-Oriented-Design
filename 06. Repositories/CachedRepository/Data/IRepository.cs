namespace CachedRepository.Data
{
    using System.Threading.Tasks;

    using CachedRepository.Data.Models;

    /// <summary>
    /// Generic Repository Interface
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public interface IRepository<T>: IReadOnlyRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
