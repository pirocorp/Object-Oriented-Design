namespace AirCombat.Core;

using System;
using System.Linq;
using Contracts;
using IO.Contracts;

public class Engine : IEngine
{
    private bool isRunning;
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(
        IReader reader, 
        IWriter writer, 
        ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;

        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            var tokens = this.reader
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var commandName = tokens[0];

            var output = this.commandInterpreter.ProcessInput(tokens);
            this.writer.WriteLine(output);

            if (commandName is "Terminate")
            {
                this.isRunning = false;
            }
        }
    }
}