namespace ObjectPool.GenericPool.Store
{
    using System;

    using static ErrorMessages;

    internal class StoreFactory
    {
        public static IItemStore<T> CreateItemStore<T>(AccessMode mode, int capacity)
            => mode switch
            {
                AccessMode.Fifo => new QueueStore<T>(capacity),
                AccessMode.Lifo => new StackStore<T>(capacity),
                AccessMode.Circular => new CircularStore<T>(capacity),
                _ => throw new ArgumentOutOfRangeException(
                    nameof(mode), 
                    mode, 
                    UnsupportedAccessMode)
            };
    }
}
