namespace Mediator;

using System.Collections.Generic;

/// <summary>
/// ConcreteMediator
/// </summary>
public class ChatRoom : IChatRoom
{
    private readonly Dictionary<string, Participant> participants;

    public ChatRoom()
    {
        this.participants = new Dictionary<string, Participant>();
    }

    public void Register(Participant participant)
    {
        if (!this.participants.ContainsKey(participant.Name))
        {
            this.participants[participant.Name] = participant;
        }

        participant.ChatRoom = this;
    }

    public void Send(string from, string to, string message)
    {
        if (this.participants.TryGetValue(to, out var participant))
        {
            participant.Receive(from, message);
        }
    }
}
