namespace DomainEvents.Interfaces;

using System;
using System.Collections.Generic;

public interface IEntity
{
    Guid Id { get; }

    List<IDomainEvent> Events { get; }
}
