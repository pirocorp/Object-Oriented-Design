namespace Interpreter;

using System;
using RomanNumbers;

public static class Program
{
    public static void Main()
    {
        var roman = new RomanNumber("MCMXXVIII");
        Console.WriteLine($"{roman.Literal} = {roman.Value}");

        roman = new RomanNumber("MMXXIII");
        Console.WriteLine($"{roman.Literal} = {roman.Value}");

    }
}
