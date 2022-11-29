namespace Mediator;

/// <summary>
/// Mediator
/// </summary>
public interface IChatRoom
{
    void Register(Participant participant);

    void Send(string from, string to, string message);
}
