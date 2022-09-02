namespace ObjectPool.GenericPool.Loader;

using Store;

/// <summary>
/// Use with Circular store
/// </summary>
internal class LazyExpanding : ILoader
{
    public T Acquire<T>(IItemStore<T> itemStore) where T : new()
    {
        lock (itemStore)
        {
            T item;

            if (itemStore.Count < itemStore.Capacity)
            {
                item = new T();
                itemStore.Store(item);
            }
            else
            {
                item = itemStore.Fetch();
            }

            return item;
        }
    }
}