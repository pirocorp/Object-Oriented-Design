namespace CachedRepository.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CachedRepository.Data.Models;

    /// <summary>
    /// Generic Repository Read-Only Interface
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(int id);

        Task<IEnumerable<T>> List();
    }
}
