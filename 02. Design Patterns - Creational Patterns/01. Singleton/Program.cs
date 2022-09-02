namespace Singleton;

using Singleton.Singletons;

using System;

public static class Program
{
    public static void Main()
    {
        Singleton<LoggerGenericLazyImplementation>();
    }

    private static void Singleton<T>() 
        where T : ILogger<T>
    {
        for (var i = 1; i <= 12; i++)
        {
            T.Instance.Queue.Add($"Log: {i}");
        }

        foreach (var log in T.Instance.Queue)
        {
            Console.WriteLine(log);
        }
    }
}
