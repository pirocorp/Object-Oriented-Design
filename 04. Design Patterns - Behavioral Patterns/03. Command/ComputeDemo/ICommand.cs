namespace Command.ComputeDemo;

public interface ICommand
{
    void Execute();

    void UnExecute();
}
