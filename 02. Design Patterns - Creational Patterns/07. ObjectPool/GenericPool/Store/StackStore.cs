namespace ObjectPool.GenericPool.Store;

using System;
using System.Collections.Generic;

using static ErrorMessages;

/// <summary>
/// LIFO storage pattern
/// </summary>
/// <typeparam name="T">Type of stored items</typeparam>
internal class StackStore<T> : IItemStore<T>
{
    private readonly int capacity;
    private readonly Stack<T> items;

    public StackStore(int capacity)
    {
        this.capacity = capacity;
        this.items = new Stack<T>(capacity);
    }

    public int Count => this.items.Count;

    public int Capacity => this.capacity;

    public T Fetch() => this.items.Pop();

    public void Store(T item)
    {
        if (this.items.Count == this.capacity)
        {
            throw new InvalidOperationException(StackStoreCapacityLimit);
        }

        this.items.Push(item);
    }
}
