namespace Decorator;

using System;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}