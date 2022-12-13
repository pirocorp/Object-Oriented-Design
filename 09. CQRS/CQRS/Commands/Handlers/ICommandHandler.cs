namespace CQRS.Commands.Handlers;

public interface ICommandHandler<in T>
{
    void Handle(T command);
}
