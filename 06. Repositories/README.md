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

Note that in this implementation, all operations are saved as they are performed; there is no Unit of Work being applied. There are a variety of ways in which Unit of Work behavior can be added to this implementation, the simplest of which being to add an explicit Save() method to the ```IRepository<T>``` method, and to only call the underlying SaveChanges() method from this method.


IQueryable?
-------

Another common question with Repositories has to do with what they return. Should they return data, or should they return queries that can be further refined before execution (**IQueryable**)? The former is safer, but the latter offers a great deal of flexibility. In fact, you can simplify your interface to only offer a single method for reading data if you go the **IQueryable** route, since from there any number of items can be returned.

A problem with this approach is that it tends to result in business logic bleeding into higher application layers, and becoming duplicated there. 

Common example in real applications is the use of "soft deletes" represented by an IsActive or IsDeleted property on an entity. Once an item has been deleted, 99% of the time it should be excluded from display in any UI scenario, so nearly every request will include something like ```.Where(foo => foo.IsActive)``` in addition to whatever other filters are present. This is better achieved within the repository, where it can be the default behavior of the List() method, or the List() method might be renamed to something like ListActive(). If it's truly necessary to view deleted/inactive items, a special List method can be used for just this (probably rare) purpose.


Running the Cached Repository Sample App
-------

This application uses seed data created by EF Migrations. You'll need to have a Docker and Docker compose installed. Check for docker compose version.

```
docker compose version
```

![image](https://user-images.githubusercontent.com/34960418/195333051-4bef877d-bce5-4920-9485-c11e5ea2d6b1.png)


Open terminal in Cached Repository folder where ```docker-compose.yml``` is located and execute:

```
docker-compose up -d
```

When application is ready you should see

![image](https://user-images.githubusercontent.com/34960418/195338069-f1330e73-a3aa-4894-a152-84cd74dea523.png)


Open browser and go to [https://localhost:8001](https://localhost:8001)

Once the app is working, your initial view of the home page should look something like this:

![image](https://user-images.githubusercontent.com/34960418/195335023-418455d3-2b80-46a0-bfb9-8773fa70179b.png)

Refresh the page and you should see the data continue to load, but the Load time should be 0 ms or close to zero. The cache is configured to reset every 5 seconds so if you continue refreshing you should periodically see a non-zero load time. In Docker Desktop in application container logs you can actually see when queries to the database are made.

![image](https://user-images.githubusercontent.com/34960418/195338533-f83bec59-c847-4eae-97f5-95a434b71a08.png)


Clen up


