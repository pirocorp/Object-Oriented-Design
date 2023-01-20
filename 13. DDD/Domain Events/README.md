# Applying Domain Events to a Simple App


Each **Entity** has a collection of **Events**.

```csharp
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

**Event Handlers** implement the `INotificationHandler<TNotification>` interface  which comes from [MediatR](https://github.com/jbogard/MediatR) library. Where `TNotification` is the raised event. `NotifyUIAppointmentConfirmed`, `NotifyUIAppointmentCreated`, and `NotifyUserAppointmentCreated` events handlers.

```csharp
public class NotifyUiAppointmentConfirmed : INotificationHandler<AppointmentConfirmed>
{
    public Task Handle(AppointmentConfirmed notification, CancellationToken cancellationToken)
    {
        ConsoleWriter.FromUiEventHandlers(
            "[UI] User Interface informed appointment for {0} confirmed at {1}",
            notification.Appointment.EmailAddress,
            notification.Appointment.ConfirmationReceivedDate.ToString());

        return Task.CompletedTask;
    }
}

public class NotifyUiAppointmentCreated : INotificationHandler<AppointmentCreated>
{
    public Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
    {
        var emailAddress = notification.Appointment.EmailAddress;

        ConsoleWriter.FromUiEventHandlers(
            "[UI] User Interface informed appointment created for {0}", 
            emailAddress);

        return Task.CompletedTask;
    }
}

public class NotifyUserAppointmentCreated : INotificationHandler<AppointmentCreated>
{
    public Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
    {
        var emailAddress = notification.Appointment.EmailAddress;

        ConsoleWriter.FromEmailEventHandlers(
            "[EMAIL] Notification email sent to {0}", 
            emailAddress);

        return Task.CompletedTask;
    }
}
```

`Appointment` **Entity** adds an event to its event list after completing the `Create` operation and before the return statement.

```csharp
public static Appointment Create(string emailAddress)
{
    Console.WriteLine("Appointment::Create()");

    var appointment = new Appointment
    {
        EmailAddress = emailAddress
    };

    appointment.Events.Add(new AppointmentCreated(appointment));

    return appointment;
}
```

`Appointment` **Entity** adds an event to its event list after completing the `Confirm` operation.

```csharp
public void Confirm(DateTime dateConfirmed)
{
    this.ConfirmationReceivedDate = dateConfirmed;

    this.Events.Add(new AppointmentConfirmed(this, dateConfirmed));
}
```

The actual dispatching of the events is done in the **Repository** **Save** method after the save is successful `await this.mediator.Publish(domainEvent).ConfigureAwait(false);`

```csharp
public async Task Save(TEntity entity)
{
    this.entities[entity.Id] = entity;
    ConsoleWriter.FromRepositories("[DATABASE] Saved entity {0}", entity.Id.ToString());

    var eventsCopy = entity.Events.ToArray();
    entity.Events.Clear();

    foreach (var domainEvent in eventsCopy)
    {
        await this.mediator.Publish(domainEvent).ConfigureAwait(false);
    }
}
```
