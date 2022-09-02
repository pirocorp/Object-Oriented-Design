namespace ObjectPool.GenericPool.Loader;

using Store;

internal interface ILoader
{
    T Acquire<T>(IItemStore<T> itemStore) where T : new();
}
