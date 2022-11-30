namespace Interpreter;

using System;
using RomanNumbers;

public static class Program
{
    public static void Main()
    {
        var romanString = "MCMXXVIII";
        var roman = new RomanNumber(romanString);

        Console.WriteLine($"{romanString} = {roman.Value}");
        Console.WriteLine($"{romanString} = {roman.Value}");
    }
}
