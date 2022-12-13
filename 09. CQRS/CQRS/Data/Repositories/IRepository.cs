namespace CQRS.Data.Repositories;

using System.Collections.Generic;

using CQRS.Data.Entities;

public interface IRepository<T> where T : EntityBase
{
    T? GetById(int id);

    IEnumerable<T> List();

    void Add(T entity);

    void Delete(T entity);

    void Edit(T entity);

    void SaveChanges();
}
