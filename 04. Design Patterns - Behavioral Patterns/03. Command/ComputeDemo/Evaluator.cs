namespace Command.ComputeDemo;

using System;
using System.Collections.Generic;

public class Evaluator
{
    private readonly Calculator calculator;
    private readonly IList<ICommand> commands;
    private int current;

    public Evaluator()
    {
        this.calculator = new Calculator();
        this.commands = new List<ICommand>();
        this.current = 0;
    }

    public void Compute(Operation operation, decimal operand)
    {
        var command = new CalculatorCommand(this.calculator, operation, operand);
        command.Execute();

        this.commands.Add(command);
        this.current++;
    }

    public void Redo(int levels)
    {
        Console.WriteLine($"\n---- Redo {levels} levels ");

        for (var i = 0; i < levels; i++)
        {
            if (this.current >= this.commands.Count - 1)
            {
                return;
            }

            var command = this.commands[this.current++];
            command.Execute();
        }
    }

    public void Undo(int levels)
    {
        Console.WriteLine($"\n---- Undo {levels} levels ");

        for (var i = 0; i < levels; i++)
        {
            if (this.current <= 0)
            {
                return;
            }

            var command = this.commands[--this.current];
            command.UnExecute();
        }
    }
}
