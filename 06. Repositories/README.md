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


Cached Repository
-------

At the most basic level, implementing a cached repository is simply a matter of overriding the methods of the base repository implementation (which must be marked as virtual), and then updating the IOC container’s registration to use the new type. Implementing a CachedAlbumRepository would look something like this:

```csharp
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
```

The above code is an example of the **Proxy** (or perhaps **Decorator**) design pattern. Proxies are all about controlling access, and the **CachedAuthorRepositoryDecorator** controls access to the **AuthorRepository** by first checking to see whether the data exists in the cache (one could make the argument that this is about adding behavior to the underlying repository, in which case the Decorator pattern, which has the same structure, would be the more appropriate label).


Unit Of Work
-------

When implementing a Repository pattern it is also important to understand the Unit of Work pattern. Fowler provides an explanation of the [Unit Of Work pattern](https://www.martinfowler.com/eaaCatalog/unitOfWork.html)

> A Unit of Work keeps track of everything you do during a business transaction that can affect the database. When you’re done, it figures out everything that needs to be done to alter the database as a result of your work.

The unit of work represents a transaction when used in data layers. Typically the unit of work will roll back the transaction if Commit() has not been invoked before being disposed.

Taking a high-level view of an ORM, such as **Entity Framework (EF)**, one might conclude that it is nothing more than an implementation of the Repository Pattern and a Unit of Work Pattern, and you would be right, It is, and it does provide an abstraction for interacting with the database.

EF Core almost eliminates the need for developers to write SQL queries directly in their code and providing the ability to design and manage the database.

**DbContext**, within Entity Framework is an example of the Unit Of Work and, **IDbSet<T>** is a repository providing an abstraction layer over the data access layer.

Generally, it is a good idea to expose your Repository layer to a Service layer, which then provides domain entity objects to the UI & Business Layer.

I would emphasis, that it is not always necessary to use the Repository pattern within your application in order to abstract Entity Framework, I would caution that this type of approach has become known as an anti-pattern.


Repository Interface

```csharp
public interface IRepository<T> : IDisposable where T : class
{
    IQueryable<T> Query(string sql, params object[] parameters);

    T Search(params object[] keyValues);

    T Single(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true);

    void Add(T entity);
    void Add(params T[] entities);
    void Add(IEnumerable<T> entities);

    void Delete(T entity);
    void Delete(object id);
    void Delete(params T[] entities);
    void Delete(IEnumerable<T> entities);

    void Update(T entity);
    void Update(params T[] entities);
    void Update(IEnumerable<T> entities);
}
```

Simple Unit Of Work interface.

```csharp
 public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    int Commit();
}

public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    TContext Context { get; }
}
```

An example of the code implementation of a class using the above would look something like this

```csharp
public class SomeService
{
	private readonly IUnitOfWork _uow;
      
    public SomeService(IUnitOrWork unit )
    {
        _uow = unit;
    }
    
    public void SomeMethod(SomeClass entity)
    {
        _uow.GetRepository<SomeClass>().Add(entity);
        _uow.Commit();        
    }
}
```

Abstracting the use of Entity Framework

As discussed previously, the most common use of the **Repository** and **Unit Of Work Pattern**, is to abstract the use of Entity Framework and not to inject the **DbContext** into the ASP.net MVC **Contollers**.

[Service Layer Pattern](https://martinfowler.com/eaaCatalog/serviceLayer.html)

> A Service Layer defines an application’s boundary and its set of available operations from the perspective of interfacing client layers. It encapsulates the application’s business logic, controlling transactions and coor-dinating responses in the implementation of its operations.

Many developers confuse the Service Layer Pattern with the Repository Pattern, the primary reason why is that the Service Layer will usually provide an abstraction for the Repository & Unit Of Work pattern in order to de-couple the presentation layer from the Repository.


Entity Framework Core is an Implementation of the Unit Of Work and Repository Pattern

![image](https://user-images.githubusercontent.com/34960418/204818098-6f5f67bc-6348-4654-aacb-d574e2fe28d0.png)


Cached Repository Sample App
==================

The Sample
-------

The sample application doesn't really do a whole lot. The home page for the web application uses Razor Pages and fetches a list of authors with their associated publications. It captures the time taken to fetch the data as seen from the UI layer:

```csharp
public class IndexModel : PageModel
{
    private readonly IReadOnlyRepository<Author> authorRepository;

    public IndexModel(IReadOnlyRepository<Author> authorRepository)
    {
        this.authorRepository = authorRepository;
    }

    public List<Author> Authors { get; set; } = new();

    public long ElapsedTimeMilliseconds { get; set; }

    public async Task OnGet()
    {
        var timer = Stopwatch.StartNew();
        Authors = (await authorRepository.List()).ToList();
        timer.Stop();
        ElapsedTimeMilliseconds = timer.ElapsedMilliseconds;
    }
}
```

The elapsed time in milliseconds is displayed on the page along with a list of authors (and a count of their resources).

Ok so a couple of things to point out here. First, the page is pretty simple. There's no conditional logic to it. There's nothing that indicates where the data is being fetched from or whether or not it should be cached.

We can see that this class depends on a service described by an interface. That interface includes the name Repository which tells us it's concerned with persistence. It's also labeled as a ReadOnly repository, so we can expect that it will only contain queries. Looking at the definition, we're not disappointed:

```csharp
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(int id);

        Task<IEnumerable<T>> List();
    }
```

Somewhere there's got to be some actual persistence logic, though, and we find that in an implementation-specific type, **EfRepository.cs**. This type actually implements a full read/write repository interface, but it's got the ReadOnly methods, too, thus satisfying that interface as well. Its List method is the only one we're concerned with:

```csharp
public virtual async Task<IEnumerable<T>> List()
            => await this.DbContext.Set<T>().ToListAsync();
```

In order to perform eager loading I'm subclassing the repo with an author-specific version that includes this implementation for **List()**

```csharp
    public override async Task<IEnumerable<Author>> List()
    {
        return await this.DbContext.Authors
            .Include(a => a.Resources)
            .ToListAsync();
    }
```

With just the code we've shown so far, we could add one line to Startup.ConfigureServices and our application would work:

```csharp
services.AddScoped<IReadOnlyRepository<Author>, AuthorRepository>();
```

Adding Caching
-------

The nice thing about the **CachedRepository** pattern is that it allows us to add caching behavior without modifying the existing functionality for fetching data from persistence, or the code that calls this code. In fact, we can add caching to the above application without touching any code in the repository implementations shown above or the Razor Page that uses them. The only place we will modify code will be in Startup.ConfigureServices, where we will wire in a new service.

The **Decorator** pattern is used to add additional functionality to an existing type. It's essentially a wrapper around existing functionality. We're going to add caching behavior as a decorator that wraps around the underlying **Repository** instance. The **Proxy** pattern is functionally the same as the **Decorator**, but the intent varies. With the **Proxy**, the intent is to control access to a resource, as opposed to adding functionality. In a sense, though, choosing whether to get data from its source or from a local cached copy is controlling access to the source data, so you can also think of the **CachedRepository** pattern as being a kind of **Proxy**, too.

The simple implementation of data caching in the **CachedAuthorRepositoryDecorator** class looks like this:

```csharp
public async Task<IEnumerable<Author>> List()
    => await this.cache
        .GetOrCreateAsync(
            AuthorModelCacheKey,
            async entry =>
            {
                entry.SetOptions(cacheOptions);
                return await this.repository.List();
            });
```

In this case the ```this.cache``` refers to an injected instance of **IMemoryCache**. In some projects, it may make sense to rely on your own interface that might wrap additional behavior, since **IMemoryCache** is a pretty low-level interface. For instance, if you find that every one of your cached repositories has basically the same code as shown above, you could reduce duplication by putting that logic into your own cache service.

```csharp
public CachedAuthorRepositoryDecorator(
    AuthorRepository repository,
    IMemoryCache cache)
```

Caches require keys, and key generation is an important aspect of a caching strategy. In this sample, the key is simply hard-coded in the Decorator class. You can also build keys based on things like class and method name, as well as arguments.

Once you have a CachedRepository class, the only thing left to do is configure your application to use it, in **ConfigureServices()**:

```csharp
// Requests for ReadOnlyRepository will use the Cached Implementation
services.AddScoped<IReadOnlyRepository<Author>, CachedAuthorRepositoryDecorator>();
services.AddScoped(typeof(EfRepository<>));
services.AddScoped<AuthorRepository>();
```

Now if you run the application, you will see that loading the large set of records requires some amount of time (100-200ms on my machines I’ve tried it on) on the first load, but then drops to 0ms for subsequent requests. The cache is set up to expire after 5 seconds, so you should see non-zero times every 5 seconds or so as you test the application.


Run the app
===========

Prerequisites
-------

This application uses seed data created by EF Migrations. You'll need to have a Docker and Docker compose installed. Check for docker compose version.

```
docker compose version
```

![image](https://user-images.githubusercontent.com/34960418/195333051-4bef877d-bce5-4920-9485-c11e5ea2d6b1.png)


Run the app
-------

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


Clean up
-------

Stop the container(s) using the following command:

```bash
docker-compose down
```

![image](https://user-images.githubusercontent.com/34960418/195339540-fd805d01-1f4a-4e74-b947-5f4202efccdd.png)


Delete all containers using the following command (if any left):

```bash
docker rm -f $(docker ps -a -q)
```

Delete all volumes using the following command (if any left):

```bash
docker volume rm $(docker volume ls -q)
```

Find docker image, it should look something like this

![image](https://user-images.githubusercontent.com/34960418/195341111-0a1e5f48-3932-4f72-b7a4-3bc0d522c324.png)


Delete docker image.

```bash
docker image rm cachedrepository_cachedrepository
```

![image](https://user-images.githubusercontent.com/34960418/195341262-ac4b05fb-eee7-49ff-888c-cf11f44ca608.png)
