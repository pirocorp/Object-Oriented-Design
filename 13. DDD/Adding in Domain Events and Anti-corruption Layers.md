# Adding in Domain Events and Anti-corruption Layers

## Introducing Domain Events

**Domain Events** are a critical part of the **Bounded Context** they provide a way to describe an important activity or state changes that occurred in the system. Then other parts of the **Domain** can respond to this **Events** in a loosely coupled manner.

In this way, the objects raising the events don't need to worry about the behavior that needs to occur when the event happens; likewise, the event-handling objects don't need to know where the event came from. This is similar to how **Repositories** allow encapsulating the data access code so the rest of the **Domain** doesn't need to know about it.

![image](https://user-images.githubusercontent.com/34960418/213712183-2c9373a8-f3c3-4a9d-ae22-b0e1f9325d9e.png)

Domain Event Features
- Can communicate outside of the domain
- Encapsulated as objects
- Each event is a full-fledged class

> Use a domain event to capture an occurrence of something that happened in the domain.

Vaughn Vernon

The **Domain Events** should be part of the **Ubiquitous Language** the customer or domain expert should understand what you are talking about when you say: "When an appointment is confirmed, an appointment confirmed event is raised."

**Domain Events** offer the same advantages to our **Model** as the events in the user interface. Rather than having to include all the behavior that might need to occur whenever the state of our objects changes, instead, we can raise an event. Then we can write different code that deals with the event keeping the design of our **Model** simple and helping to ensure that each class has only one responsibility. 

Essentially the **Domain Event** is a **Message**, a record about something that occurred in the past, which may be of interest to other parts of our application or even other applications entirely.

## Identifying Domain Events in Our System

Domain Events Pointers

- When this happens, then something else should happen. “If that happens…”, “Notify the user when…” , “Inform the user if…”
- Domain events represent the past
- Typically, they are immutable
- Name the event using the bounded context’s ubiquitous language
- Use the command name causing the event to be fired

Domain Event Examples

- User Authenticated
- Appointment Confirmed
- Payment Received

Create Events as Needed, Not Just in Case - Only create **Domain Events** if you have some behavior that needs to occur when the event occurs and want to decuple the behavior from its trigger. You only need to do this when the behavior doesn't belong in the class triggering it. (YAGNI)


## Designing Domain Events

Each event is its own class

```csharp
public class AppointmentScheduled
{
    . . .
}

public class AppointmentConfirmed
{
    . . .
}
```

Include when the event took place - The code handling the event may run sometime after the event occurs. It can be helpful to create an interface or base class that defines the common requirements of your **Domain Events**. For example, capturing the time event occurred. 


```csharp
public abstract class BaseDomainEvent : INotification
{
    public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
}
```

Capture eventspecific details - You should include the current state of the **Entity** in the **Event's** definition. Think about what information you need to trigger the **Event** again. This can provide you with the set of information that is important to this **Event**. Similarly, you may need to know the identities of any **Aggregates** involved in the **Event**. Even if you don't include the entire **Aggregate** itself, this will allow the event handler to pull the information back from the system, which they may require when handling the **Event**.

```csharp
public class AppointmentScheduledEvent : BaseDomainEvent
{
    public AppointmentScheduledEvent (Appointment appointment) 
        : this()
    {
        AppointmentScheduled = appointment;
    }
    . . .
}
```

Event fields are initialized in the constructor. No behavior or side effects.

```csharp
public AppointmentScheduledEvent()
{
    this.Id = Guid.NewGuid();
}
```

## Applying Domain Events to a Simple App

**Aggregates** should work whether accessed directly or through services. The **Domain Model** should work with either workflow. **Aggregate** doesn’t need to know what actions must be performed. Inform the app about an event. App triggers the needed actions. Consider the order of operations (E.g., persistence should succeed before notifications are sent). Your **Domain Events** and **Handlers** should never fail. Don't build your behavior around exceptions that might be thrown from event handlers.

![image](https://user-images.githubusercontent.com/34960418/213749813-44f4b0fc-285a-40e2-a5d5-97a90b33ed4e.png)

Putting all logic into services leads to anemic domain models.

Each **Entity** has a collection of **Events**.

```chsarp
public interface IEntity
{
    List<IDomainEvent> Events { get; }
    . . .
}

public class Appointment : IEntity
{
    . . .
    public List<IDomainEvent> Events { get; set; }
    . . .
}
```

**Events** implement the `IDomainEvent` interface.

```csharp
public interface IDomainEvent : INotification 
{
    DateTime DateOccurred { get; }
}
```

**Event Handlers** implement the `IHandle` interface.

```csharp
public interface IHandle<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
    Task Handle(TNotification notification, CancellationToken cancellationToken);
}
```

`AppointmentCreated` and `AppointmentConfirmed` events.

```csharp
public class AppointmentCreated : IDomainEvent
{
    public AppointmentCreated(Appointment appointment, DateTime dateCreated)
    {
        this.Appointment = appointment;
        this.DateOccurred = dateCreated;
    }

    public AppointmentCreated(Appointment appointment) : this(appointment, DateTime.Now)
    {
    }

    public Appointment Appointment { get; set; }

    public DateTime DateOccurred { get; private set; }
}   

public class AppointmentConfirmed : IDomainEvent
{
    public AppointmentConfirmed(Appointment appointment, DateTime dateConfirmed)
    {
        this.Appointment = appointment;
        this.DateOccurred = dateConfirmed;
    }

    public AppointmentConfirmed(Appointment appointment) 
        : this(appointment, DateTime.Now)
    {
    }

    public Appointment Appointment { get; set; }

    public DateTime DateOccurred { get; private set; }
}
```
