namespace Memento;

using System;

public class Originator
{
    private string state;

    public Originator()
    {
        this.state = string.Empty;
    }

    public string State
    {
        get => this.state;
        set
        {
            this.state = value;
            Console.WriteLine($"State = {this.state}");
        }
    }

    public Memento CreateMemento() => new (this.state);

    public void RestoreState(Memento memento)
    {
        Console.WriteLine("Restore state...");

        this.State = memento.State;
    }
}
