namespace ArdalisRating;

using System;

using ArdalisRating.Core;
using ArdalisRating.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Ardalis Insurance Rating System Starting...");

        var engine = InitializeEngine();
        engine.Rate();

        if (engine.Rating > 0)
        {
            Console.WriteLine($"Rating: {engine.Rating}");
        }
        else
        {
            Console.WriteLine("No rating produced.");
        }
    }

    private static RatingEngine InitializeEngine()
        => new ServiceCollection()
            .RegisterDependencies()
            .BuildServiceProvider()
            .GetRequiredService<RatingEngine>();
}
