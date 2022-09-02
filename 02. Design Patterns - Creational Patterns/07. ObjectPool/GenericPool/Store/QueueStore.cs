namespace ObjectPool.GenericPool.Store;

using System;
using System.Collections.Generic;

using static ErrorMessages;

/// <summary>
/// FIFO storage pattern
/// </summary>
/// <typeparam name="T">Type of stored items</typeparam>
internal class QueueStore<T> : IItemStore<T>
{
    private readonly int capacity;

    private readonly Queue<T> items;

    public QueueStore(int capacity)
    {
        this.capacity = capacity;
        this.items = new Queue<T>(capacity);
    }

    public int Count => this.items.Count;

    public int Capacity => this.capacity;

    public T Fetch() => this.items.Dequeue();

    public void Store(T item)
    {
        if (this.items.Count == this.capacity)
        {
            throw new InvalidOperationException(QueueStoreCapacityLimit);
        }

        this.items.Enqueue(item);
    }
}
