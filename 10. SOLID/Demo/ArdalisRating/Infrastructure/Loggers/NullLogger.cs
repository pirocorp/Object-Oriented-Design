namespace ArdalisRating.Infrastructure.Loggers;

using ArdalisRating.Core.Interfaces;

public class NullLogger : ILogger
{
    public void Log(string message)
    { }
}
