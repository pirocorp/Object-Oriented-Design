namespace DomainEvents.Interfaces;

using MediatR;

public interface IHandle<in TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
    //Task Handle(TNotification notification, CancellationToken cancellationToken);
}
