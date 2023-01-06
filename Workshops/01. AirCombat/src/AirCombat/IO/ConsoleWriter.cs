namespace AirCombat.IO;

using System;

using AirCombat.IO.Contracts;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}
