namespace ObjectPool.SimplePool
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// Object pool by using a ConcurrentBag
    /// </summary>
    ///
    /// <remarks> 
    /// The Microsoft.Extensions.ObjectPool.ObjectPool/<T/>
    /// type already exists under the Microsoft.Extensions.ObjectPool namespace.
    /// Consider using the available type before creating your own implementation,
    /// which includes many additional features.
    /// 
    /// https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/how-to-create-an-object-pool
    /// </remarks>
    ///
    /// <remarks>
    /// ConcurrentBag is a Thread-Safe Collection
    ///
    /// Multiple threads can safely and efficiently add or remove items
    /// from these collections, without requiring additional
    /// synchronization in user code.
    ///
    /// The ConcurrentBag/<T/> is used to store the objects because it
    /// supports fast insertion and removal, especially when the same
    /// thread is both adding and removing items.
    ///
    /// https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
    /// </remarks>
    public class SimplePool<T>
    {
        private readonly ConcurrentBag<T> items;
        private readonly Func<T> itemGenerator;

        public SimplePool(Func<T> itemGenerator)
        {
            this.itemGenerator = itemGenerator;
            this.items = new ConcurrentBag<T>();
        }

        public int Count => items.Count;

        public T Get() 
            => this.items.TryTake(out var item) 
                ? item 
                : this.itemGenerator();

        public void Return(T item) 
            => this.items.Add(item);
    }
}
