namespace Command.ComputeDemo;

using System;

public class Calculator
{
    private decimal current;

    public void Operation(Operation operation, decimal operand)
    {
        var result = operation switch
        {
            ComputeDemo.Operation.Addition => current += operand,
            ComputeDemo.Operation.Subtraction => current -= operand,
            ComputeDemo.Operation.Division => current /= operand,
            ComputeDemo.Operation.Multiplication => current *= operand,
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };

        Console.WriteLine($"Current value = {result} (following {operation} by {operand})");
    }
}

