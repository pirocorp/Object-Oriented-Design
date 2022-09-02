namespace ObjectPool.GenericPool.Store;

using System;
using System.Linq;

using static ErrorMessages;

/// <summary>
/// Circular buffer storage pattern
/// </summary>
/// <typeparam name="T">Type of stored items</typeparam>
internal class CircularStore<T> : IItemStore<T>
{
    private readonly Slot<T>?[] items;
    private readonly int capacity;
    private int position;

    public CircularStore(int capacity)
    {
        this.items = new Slot<T>?[capacity];
        this.capacity = capacity;
        this.position = 0;
    }

    public int Count => this.items.Count(x => x != null);

    public int Capacity => this.capacity;

    private int Unavailable => this.items.Count(x => x is null || x.InUse);

    public T Fetch()
    {
        if (this.Unavailable == this.capacity)
        {
            throw new InvalidOperationException(CircularStoreNoAvailableSlot);
        }

        while (this.items[this.position] is null || this.items[this.position]!.InUse)
        {
            this.Advance();
        }

        var slot = this.items[this.position];
        
        slot!.InUse = true;
        return slot.Item;
    }

    public void Store(T item)
    {
        var slot = this.items
            .Where(x => x is not null)
            .FirstOrDefault(x => object.Equals(x!.Item, item));

        if (slot is null)
        {
            if (this.Count == this.capacity)
            {
                throw new InvalidOperationException(CircularStoreNoFreeSlot);
            }

            slot = new Slot<T>(item);

            while (this.items[this.position] is not null)
            {
                this.Advance();
            }

            this.items[this.position] = slot;
        }

        slot.InUse = false;
    }

    private void Advance()
    {
        this.position = (this.position + 1) % this.items.Length;
    }
}
