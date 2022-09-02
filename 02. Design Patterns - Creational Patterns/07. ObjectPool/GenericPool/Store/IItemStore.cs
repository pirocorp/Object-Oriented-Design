namespace ObjectPool.GenericPool.Store;

internal interface IItemStore<T>
{
    int Count { get; }

    int Capacity { get; }

    T Fetch();

    void Store(T item);
}