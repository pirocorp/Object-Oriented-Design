namespace ArdalisRating.Tests;

using System.Collections.Generic;

using ArdalisRating.Core.Interfaces;

public class FakeLogger : ILogger
{
    public List<string> LoggedMessages { get; } = new List<string>();

    public void Log(string message)
    {
        this.LoggedMessages.Add(message);
    }
}
