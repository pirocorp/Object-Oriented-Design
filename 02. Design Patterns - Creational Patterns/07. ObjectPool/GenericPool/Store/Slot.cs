namespace ObjectPool.GenericPool.Store;

internal class Slot<T>
{
    public Slot(T item)
    {
        this.Item = item;
    }

    public T Item { get; private set; }

    public bool InUse { get; set; }
}
