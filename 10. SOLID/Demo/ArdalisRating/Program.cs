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

        var response = engine.Rating > 0
            ? $"Rating: {engine.Rating}"
            : "No rating produced.";

        Console.WriteLine(response);
    }

    private static RatingEngine InitializeEngine()
        => new ServiceCollection()
            .RegisterDependencies()
            .BuildServiceProvider()
            .GetRequiredService<RatingEngine>();
}
