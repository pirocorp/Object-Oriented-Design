namespace AirCombat;

using AirCombat.Core;
using AirCombat.Core.Contracts;
using AirCombat.IO;
using AirCombat.IO.Contracts;

public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IBattleOperator battleOperator = new BattleOperator();
        IManager manager = new Manager(battleOperator);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

        IEngine engine = new Engine(
            reader,
            writer,
            commandInterpreter);

        engine.Run();
    }
}
