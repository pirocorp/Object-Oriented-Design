namespace AirCombat.IO;

using System;

using AirCombat.IO.Contracts;

public class ConsoleReader : IReader
{
    public string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
