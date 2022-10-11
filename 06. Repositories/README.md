Repository Pattern
==================

Description

The Repository Pattern has gained quite a bit of popularity since it was first introduced as a part of **Domain-Driven Design** in 2004. Essentially, it provides an abstraction of data, so that your application can work with a simple abstraction that has an interface approximating that of a collection. 

Adding, removing, updating, and selecting items from this collection is done through a series of straightforward methods, without the need to deal with database concerns like connections, commands, cursors, or readers. Using this pattern can help achieve loose coupling and can keep domain objects **persistence ignorant**. 

Although the pattern is very popular (or perhaps because of this), it is also frequently misunderstood and misused. There are many different ways to implement the Repository pattern. Let's consider a few of them, and their merits and drawbacks.


Repository Per Entity or Business Object
-------

The simplest approach, especially with an existing system, is to create a new Repository implementation for each business object you need to store to or retrieve from your persistence layer. Further, you should only implement the specific methods you are calling in your application. 

Avoid the trap of creating a "standard" repository class, base class, or default interface that you must implement for all repositories. Yes, if you need to have an Update or a Delete method, you should strive to make its interface consistent (does Delete take an ID, or does it take the object itself?), but don't implement a Delete method on your LookupTableRepository that you're only ever going to be calling List() on. 

The biggest benefit of this approach is **YAGNI** - you won't waste any time implementing methods that never get called.


Generic Repository Interface
-------

Another approach is to go ahead and create a simple, generic interface for your Repository. You can constrain what kind of types it works with to be of a certain type, or to implement a certain interface (e.g. ensuring it has an Id property, as is done below using a base class).

An example of a generic C# repository interface

```csharp
public interface IRepository<T> where T : EntityBase
{
    T GetById(int id);
    IEnumerable<T> List();
    IEnumerable<T> List(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Delete(T entity);
    void Edit(T entity);
}

public abstract class EntityBase
{
   public int Id { get; protected set; }
}
```

The advantage of this approach is that it ensures you have a common interface for working with any of your objects. You can also simplify the implementation by using a Generic Repository Implementation (below). Note that taking in a predicate eliminates the need to return an IQueryable, since any filter details can be passed into the repository. This can still lead to leaking of data access details into calling code, though.


Generic Repository Implementation
-------

Assuming you create a Generic Repository Interface, you can implement the interface generically as well. Once this is done, you can easily create repositories for any given type without having to write any new code, and your classes the declare dependencies can simply specify ```IRepository<Item>``` as the type, and it's easy for your IoC container to match that up with a ```Repository<Item>``` implementation. You can see an example Generic Repository Implementation, using Entity Framework, here.

```csharp
public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly ApplicationDbContext _dbContext;
    
    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public virtual T GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }
    
    public virtual IEnumerable<T> List()
    {
        return _dbContext.Set<T>().AsEnumerable();
    }
    
    public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>()
               .Where(predicate)
               .AsEnumerable();
    }
    
    public void Insert(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
    }
    
    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }
    
    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
    }
}
```
