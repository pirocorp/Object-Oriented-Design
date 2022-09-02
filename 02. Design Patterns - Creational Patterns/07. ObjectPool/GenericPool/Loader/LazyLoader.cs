namespace ObjectPool.GenericPool.Loader;

using System;
using Store;

/// <summary>
/// Use with FIFO and LIFO store
/// </summary>
internal class LazyLoader : ILoader
{
    public T Acquire<T>(IItemStore<T> itemStore) where T : new()
    {
        lock (itemStore)
        {
            return itemStore.Count != 0 ? itemStore.Fetch() : new T();
        }
    }
}
