namespace DomainEvents;

using System;

public static class ConsoleWriter
{
    public static void FromUiEventHandlers(string message, params object?[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message, args);
        Console.ResetColor();
    }

    public static void FromEmailEventHandlers(string message, params object?[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message, args);
        Console.ResetColor();
    }

    public static void FromRepositories(string message, params object?[] args)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message, args);
        Console.ResetColor();
    }
}
