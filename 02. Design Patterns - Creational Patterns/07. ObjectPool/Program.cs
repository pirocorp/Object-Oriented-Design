namespace ObjectPool;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GenericPool;
using GenericPool.Loader;
using GenericPool.Store;

public static class Program
{
    private static readonly object ConsoleWriterLock = new();
    private static readonly Pool<Test> Pool 
        = new(5, LoadingMode.Lazy, AccessMode.Fifo);

    public static void Main()
    {
        for (var i = 0; i < Pool.Capacity * 2; i++)
        {
            var thread = new Thread(() => Test(i));
            thread.Start();
        }
    }

    public static void Test(int threadId)
    {
        for (var i = 0; i < 10_000; i++)
        {
            var t = Pool.Acquire();

            lock (ConsoleWriterLock)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine($"Acquire by {threadId}: " + t);
            }

            Thread.Sleep(Rand.Next);

            lock (ConsoleWriterLock)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Release by {threadId}: " + t);

                Pool.Release(t);
            }
        }
    }
}
