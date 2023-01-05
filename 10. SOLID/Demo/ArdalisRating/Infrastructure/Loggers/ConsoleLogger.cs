namespace ArdalisRating.Infrastructure.Loggers;

using System;

using ArdalisRating.Core.Interfaces;

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}
