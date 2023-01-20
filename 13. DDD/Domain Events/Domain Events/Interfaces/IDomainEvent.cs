namespace DomainEvents.Interfaces;

using System;

using MediatR;

public interface IDomainEvent : INotification 
{
    DateTime DateOccurred { get; }
}
