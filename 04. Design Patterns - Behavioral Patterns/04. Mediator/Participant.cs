namespace Mediator;

using System;

/// <summary>
/// Abstract colleague class
/// </summary>
public class Participant
{
    public Participant(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public ChatRoom? ChatRoom { get; set; }

    public void Send(string to, string message)
    {
        this.ChatRoom?.Send(this.Name, to, message);
    }

    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"{from} to {this.Name}: '{message}'");
    }
}
