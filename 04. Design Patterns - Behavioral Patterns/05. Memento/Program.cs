namespace Memento;

using System;

public static class Program
{
    public static void Main()
    {
        var originator = new Originator
        {
            State = "On"
        };

        // Store initial state

        var caretaker = new Caretaker
        {
            Memento = originator.CreateMemento()
        };

        // Continue changing originator

        originator.State = "Off";

        // Restore saved state

        originator.RestoreState(caretaker.Memento);
    }
}
