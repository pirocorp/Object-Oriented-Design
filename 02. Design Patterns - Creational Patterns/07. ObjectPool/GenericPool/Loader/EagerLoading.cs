namespace ObjectPool.GenericPool.Loader;

using Store;

/// <summary>
/// Use with FIFO, LIFO and Circular store
/// </summary>
internal class EagerLoading : ILoader
{
    public T Acquire<T>(IItemStore<T> itemStore) where T : new()
    {
        lock (itemStore)
        {
            return itemStore.Fetch();
        }
    }
}
