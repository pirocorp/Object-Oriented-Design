namespace ObjectPool;

using System;
using System.Threading;
using System.Threading.Tasks;
using GenericPool;
using GenericPool.Loader;
using GenericPool.Store;
using SimplePool;

public static class Program
{
    private static readonly object ConsoleWriterLock = new();
    private static readonly Pool<Test> Pool 
        = new(5, LoadingMode.Lazy, AccessMode.Fifo);

    public static void Main()
    {
        // GenericPoolDemo();
        SimplePoolDemo();
    }

    private static void SimplePoolDemo()
    {
        using var cts = new CancellationTokenSource();

        // Create an opportunity for the user to cancel.
        _ = Task.Run(() =>
        {
            if (char.ToUpperInvariant(Console.ReadKey().KeyChar) == 'C')
            {
                cts.Cancel();
            }

        }, cts.Token);

        var pool = new SimplePool<ExampleObject>(() => new ExampleObject());

        // Create a high demand for ExampleObject instance.
        Parallel.For(0, 1_000_000, (i, loopState) =>
        {
            Console.WriteLine($"Pool Count: {pool.Count}");

            var example = pool.Get();
            try
            {
                Console.CursorLeft = 0;

                // This is the bottleneck in our application. All threads in this loop
                // must serialize their access to the static Console class.
                Console.WriteLine($"{example.GetValue(i):####.####}");
            }
            finally
            {
                pool.Return(example);
            }

            if (cts.Token.IsCancellationRequested)
            {
                loopState.Stop();
            }
        });

        Console.WriteLine("Press the Enter key to exit.");
        Console.ReadLine();
    }

    private static void GenericPoolDemo()
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
