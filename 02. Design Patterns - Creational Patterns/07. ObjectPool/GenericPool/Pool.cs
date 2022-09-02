namespace ObjectPool.GenericPool;

using System;
using System.Threading;
using Loader;
using Store;

using static ErrorMessages;

/// <summary>
/// Pool class handle the common issues like thread-safety,
/// but use a different "item store" for each access pattern.
///
/// </summary>
/// 
/// <remarks>
/// LIFO is easily represented by a stack, FIFO is a queue,
/// and circular buffer implementation using a List<T> and index
/// pointer to approximate a round-robin access pattern.
/// </remarks>
///
/// <remarks>
/// Using the Semaphore to control concurrency instead of religiously
/// checking the status of the item store. As long as acquired items
/// are correctly released, there's nothing to worry about
/// </remarks>
/// <typeparam name="T">Objects in the pool</typeparam>
public class Pool<T> : IDisposable where T : new()
{
    private readonly int capacity;

    private readonly LoadingMode loadingMode;
    private readonly AccessMode accessMode;

    private readonly Semaphore sync;
    private readonly IItemStore<T> itemStore;
    private readonly ILoader loader;

    public Pool(int size, LoadingMode loadingMode, AccessMode accessMode)
    {
        if (size <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(size), 
                PoolMustBeWithPositiveSize);
        }

        this.capacity = size;
        this.sync = new Semaphore(size, size);

        this.loadingMode = loadingMode;
        this.accessMode = accessMode;

        this.itemStore = StoreFactory.CreateItemStore<T>(accessMode, capacity);
        this.loader = LoaderFactory.CreateLoader(loadingMode, accessMode);

        if (loadingMode == LoadingMode.Eager)
        {
            PreLoadItems();
        }
    }

    public int Capacity => this.capacity;

    public T Acquire()
    {
        sync.WaitOne();

        lock (this.itemStore)
        {
            return this.loader.Acquire(this.itemStore);
        }
    }

    public void Release(T item)
    {
        lock (itemStore)
        {
            itemStore.Store(item);

            sync.Release();
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        this.ReleaseUnmanagedResources();

        if (disposing)
        {
            sync.Dispose();
        }
    }

    private void PreLoadItems()
    {
        lock (this.itemStore)
        {
            for (var i = 0; i < itemStore.Capacity; i++)
            {
                var item = new T();
                itemStore.Store(item);
            }
        }
    }

    private void ReleaseUnmanagedResources()
    {
        if (!typeof(IDisposable).IsAssignableFrom(typeof(T)))
        {
            return;
        }

        lock (itemStore)
        {
            while (itemStore.Count > 0)
            {
                var disposable = (IDisposable?) itemStore.Fetch();
                disposable?.Dispose();
            }
        }
    }
    
    ~Pool()
    {
        this.Dispose(false);
    }
}
