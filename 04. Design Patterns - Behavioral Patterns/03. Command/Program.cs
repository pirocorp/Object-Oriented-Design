namespace Command;

using Command.ComputeDemo;
using Command.SwitchDemo;

public static class Program
{
    public static void Main()
    {
        SwitchDemo();

        EvaluatorDemo();
    }

    private static void SwitchDemo()
    {
        var lamp = new Light();

        // Pass reference to the lamp instance to each command
        var switchClose = new CloseSwitchCommand(lamp);
        var switchOpen = new OpenSwitchCommand(lamp);

        var @switch = new Switch(switchClose, switchOpen);

        @switch.Close();
        @switch.Open();
    }

    private static void EvaluatorDemo()
    {
        var evaluator = new Evaluator();

        evaluator.Compute(Operation.Addition, 100);
        evaluator.Compute(Operation.Subtraction, 50);
        evaluator.Compute(Operation.Multiplication, 10);
        evaluator.Compute(Operation.Division, 2);

        evaluator.Undo(4);
        evaluator.Redo(3);
    }
}
