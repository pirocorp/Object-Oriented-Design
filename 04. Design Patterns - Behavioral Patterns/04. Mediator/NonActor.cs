namespace Mediator;

using System;

/// <summary>
/// Concrete colleague classes
/// </summary>
public class NonActor : Participant
{
    public NonActor(string name) 
        : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.Write("To an non-Actor: ");

        base.Receive(from, message);
    }
}
