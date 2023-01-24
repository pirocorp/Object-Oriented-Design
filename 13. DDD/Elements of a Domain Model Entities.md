# Elements of a Domain Model : Entities

Entity & Context are Common Software Terms

|         | Entity Framework Core                                                                      | Domain-Driven Design                                                       |
|---------|--------------------------------------------------------------------------------------------|----------------------------------------------------------------------------|
| Entity  | A data model class with a key that is mapped to a table in a database                      | A domain class with an identity for tracking                               |
| Context | A DbContext class provides access to entities and defines how entities map to the database | A Bounded Context defines the scope and boundaries of a subset of a domain |


## Entity

> Entities (a.k.a. Reference Objects) ... are not fundamentally defined by their properties, but rather by a thread of continuity and identity.
>
> An object defined primarily by its identity is called an ENTITY.
>
> An ENTITY is anything that has continuity through a life cycle and distinctions independent of attributes that are important to the application's user.

Eric Evans


## Focusing on the Domain

Shift Thinking from DB-Driven to Domain-Driven. From Designing software based on data storage needs to Designing software based on business needs.

> [The Domain Layer is] responsible for representing **concepts of the business, information about the business situation, and business rules**. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure. **This layer is the heart of business software**.

Eric Evans

### Focus on Behaviors, Not Attributes. 

In the typical data-driven app, we focus on properties. Sometimes, we are all about editing properties and the state of our objects. However, when we are modeling the domain, we need to focus on the behaviors of that domain, not simply on changing the state of objects.

Behavior Examples:

- **Schedule** an appointment for a checkup
- **Book** a room
- **Add** item to vet’s calendar
- **Note** a pet’s weight
- **Request** lab work
- **Notify** pet owner of vaccinations due
- **Accept** a new patient

Behavior Examples as Events:

- **Scheduled** - an appointment for a checkup
- **Booked** - a room
- **Added** - item to vet’s calendar
- **Noted** - a pet’s weight
- **Requested** - lab work
- **Notified** - pet owner of vaccinations due
- **Accepted** - a new patient


## Comparing Anemic and Rich Domain Models

The anemic Domain Model is a Domain Model that is focused on the state of its objects. 

This is one of those anti-patterns that's been around for quite a long time, yet seems to be having a particular spurt at the moment. As great boosters of a proper Domain Model, this is not a good thing.

The basic symptom of an Anemic Domain Model is that at first blush it looks like the real thing. There are objects, many named after the nouns in the domain space, and these objects are connected with the rich relationships and structure that true domain models have. The catch comes when you look at the behavior, and you realize that there is hardly any behavior on these objects, making them little more than bags of getters and setters. Indeed often these models come with design rules that say that you are not to put any domain logic in the the domain objects. Instead there are a set of service objects which capture all the domain logic, carrying out all the computation and updating the model objects with the results. These services live on top of the domain model and use the domain model for data.

The fundamental horror of this anti-pattern is that it's so contrary to the basic idea of object-oriented design; which is to combine data and process together. The anemic domain model is really just a procedural style design, exactly the kind of thing that object bigots like me (and Eric) have been fighting since our early days in Smalltalk. What's worse, many people think that anemic objects are real objects, and thus completely miss the point of what object-oriented design is all about.

In essence the problem with anemic domain models is that they incur all of the costs of a domain model, without yielding any of the benefits. The primary cost is the awkwardness of mapping to a database, which typically results in a whole layer of O/R mapping. This is worthwhile iff you use the powerful OO techniques to organize complex logic. By pulling all the behavior out into services, however, you essentially end up with Transaction Scripts, and thus lose the advantages that the domain model can bring.

> Application Layer [his name for Service Layer]: Defines the jobs the software is supposed to do and directs the expressive domain objects to work out problems. The tasks this layer is responsible for are meaningful to the business or necessary for interaction with the application layers of other systems. This layer is kept thin. It does not contain business rules or knowledge, but only coordinates tasks and delegates work to collaborations of domain objects in the next layer down. It does not have state reflecting the business situation, but it can have state that reflects the progress of a task for the user or the program.>
>
> Domain Layer (or Model Layer): Responsible for representing concepts of the business, information about the business situation, and business rules. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure. This layer is the heart of business software.

Eric Evans


The key point here is that the Service Layer is thin - all the key logic lies in the domain layer. He reiterates this point in his service pattern:

> Now, the more common mistake is to give up too easily on fitting the behavior into an appropriate object, gradually slipping toward procedural programming.

Eric Evans


## Understanding Entities

Two Types of Objects in DDD:

- Defined by an **identity**
- Defined by its **values**


> Many objects are not fundamentally defined by their attributes, but rather by a thread of continuity and identity.

Eric Evans

Entities Have Identity And Are Mutable. An Entity is something that we can be able to **track**, **locate**, **retrieve** and **store**. And we do that with an identity key. Its properties may change, so we cant use its properties to identify the object.


```mermaid
  flowchart LR
    id5(Entities)
    id6(Value Objects)
    
    id7(Repositories)
    id8(Aggregates)
    id9(Factories)
       
    id5 -- "access with" --> id7
    id5 -- "maintain integrity with" --> id8
    id5 -- "act as root of" --> id8
    id5 -- "encapsulate with" --> id9
    
    id6 -- "encapsulate with" --> id8
    id6 -- "encapsulate with" --> id9
    
    id8 -- "access with" --> id7
    id8 -- "encapsulate with" --> id9
```

![image](https://user-images.githubusercontent.com/34960418/211600794-6c51c409-2b14-4a14-87cd-3aec64c8de6a.png)


## Differentiating CRUD from Complex Problems that Benefit from DDD

### CRUD Classes for Client & Patient Managmenet in other bounded context (Clinic Management App)

These classes are not designed using Domain Driven Design.

```csharp
public class Client : BaseEntity<int>, IAggregateRoot
{
    public string FullName { get; set; }
    public string PreferredName { get; set; }
    public string Salutation { get; set; }
    public string EmailAddress { get; set; }
    public int PreferredDoctorId { get; set; }
    public IList<Patient> Patients { get; private set; } = new List<Patient>();

    public Client(string fullName,
        string preferredName,
        string salutation,
        int preferredDoctorId,
        string emailAddress)
    {
        FullName = fullName;
        PreferredName = preferredName;
        Salutation = salutation;
        PreferredDoctorId = preferredDoctorId;
        EmailAddress = emailAddress;
    }

    public override string ToString()
    {
        return FullName.ToString();
    }
}
```


```csharp
public class Patient : BaseEntity<int>
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Sex { get; set; }
    public AnimalType AnimalType { get; set; }
    public int? PreferredDoctorId { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
```


### Apointment Scheduling Context  (Front Desk App)

In Apointment Scheduling Context the Client, Patient, Doctor, and Room classes here differ entirely from the CRUD classes above. However, they have a subset from the same properties of the CRUD classes. But here, they are used just as lookup data and they are read-only.

![image](https://user-images.githubusercontent.com/34960418/211604229-fbfc0646-087c-4f7f-8e39-aabee478cf8d.png)


## Switching Between Contexts in a UI

User interface should be designed to hide the existence of bounded contexts from end users. 


### Ubiquitous Language to the Rescue

![image](https://user-images.githubusercontent.com/34960418/211813752-079008eb-1781-4165-ad13-add6d2b6561e.png)


## Using GUIDs or Ints for Identity Values

GUIDs as Unique Identifiers with No Database Dependency. It is easier for the CRUD entities (not designed with the DDD) to use `int` for their identities (database-generated identities). For DDD entities (ex.: Appointment), using GUIDs is much easier than relying on a database. Not only is it easier, but it follows DDD principles more clearly since we will build all our domain logic around the given entity (ex.: Appointment) without involving the database.

- GUID doesn’t depend on database
- Database performance favors int for keys
- You can use both!


## Responsibility of Entities

> Their core responsibility is identity and life-cycle
> 
> Single Responsibility is a good principle to apply to entities. It points you toward the sort of responsibility that an entity should retain. Anything that doesn't fall in that category we ought to put somewhere else.


Eric Evans


## Implementing Entities in Code

The `BaseEntity<T>` class is an abstract class, so we can't create a `BaseEntity` object. We must create something that is a `BaseEntity` object, such as an `Appointment`. 


The `BaseEntity<T>` class also has a property to hold a list of domain events that will be defined explicitly for each types that inherit from this `BaseEntity<T>`.

```csharp 
public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
``` 


```csharp
/// <summary>
/// Base types for all Entities which track state using a given Id.
/// </summary>
public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }

    public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
}
```

The `Appointment` class associates the `Patient` with the `Doctor`, `Room`, and `AppointmentType` and includes the appointment's start and end times. The `Appointment` class inherits from `BaseEntity<T>`, a generic base class. In this case, it is a `BaseEntity<Guid>`. The `Guid` defines the type of identity property.

`Appointment` uses **GUID** to avoid depending on a database for **ID** generation. So using **GUID** lets me create that id right upfront as I'm creating a new `Appointment`. So I'm giving it its **ID**.

`Appointment` has a parameters constructor to ensure that we create `Appointment` in a valid state. So that means passing all necessary elements that the 
`Appointment` needs to have. And we have some Guards to ensure valid values have been passed.

```csharp
public Appointment(
    Guid id,
    int appointmentTypeId,
    Guid scheduleId,
    int clientId,
    int doctorId,
    int patientId,
    int roomId,
    DateTimeOffsetRange timeRange, // EF Core 5 cannot provide this type
    string title,
    DateTime? dateTimeConfirmed = null)
{
    Id = Guard.Against.Default(id, nameof(id));
    AppointmentTypeId = Guard.Against.NegativeOrZero(appointmentTypeId, nameof(appointmentTypeId));
    ScheduleId = Guard.Against.Default(scheduleId, nameof(scheduleId));
    ClientId = Guard.Against.NegativeOrZero(clientId, nameof(clientId));
    DoctorId = Guard.Against.NegativeOrZero(doctorId, nameof(doctorId));
    PatientId = Guard.Against.NegativeOrZero(patientId, nameof(patientId));
    RoomId = Guard.Against.NegativeOrZero(roomId, nameof(roomId));
    TimeRange = Guard.Against.Null(timeRange, nameof(timeRange));
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    DateTimeConfirmed = dateTimeConfirmed;
}
```

Guards are a set of reusable functions. In this case, stored in the `Shared Kernel`.

When we need to modify the `Appointment`, we will do this through a method. For instance, if we want to change what room an `Appointment` is scheduled, we will do this through a method rather than just a setter. We do this because there is additional behavior we may want to do. In this case, we have some `Guards` again to ensure valid values have been passed. And we also want to raise an `AppointmentUpdatedEvent` that we might handle and send a `Notification` or perform some other action.

```csharp

public void UpdateRoom(int newRoomId)
{
    Guard.Against.NegativeOrZero(newRoomId, nameof(newRoomId));
    if (newRoomId == RoomId) return;

    RoomId = newRoomId;

    var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
    Events.Add(appointmentUpdatedEvent);
}
```

The whole `Appointment` implementation.

```csharp
public class Appointment : BaseEntity<Guid>
{
    public Appointment(
        Guid id,
        int appointmentTypeId,
        Guid scheduleId,
        int clientId,
        int doctorId,
        int patientId,
        int roomId,
        DateTimeOffsetRange timeRange, // EF Core 5 cannot provide this type
        string title,
        DateTime? dateTimeConfirmed = null)
    {
        Id = Guard.Against.Default(id, nameof(id));
        AppointmentTypeId = Guard.Against.NegativeOrZero(appointmentTypeId, nameof(appointmentTypeId));
        ScheduleId = Guard.Against.Default(scheduleId, nameof(scheduleId));
        ClientId = Guard.Against.NegativeOrZero(clientId, nameof(clientId));
        DoctorId = Guard.Against.NegativeOrZero(doctorId, nameof(doctorId));
        PatientId = Guard.Against.NegativeOrZero(patientId, nameof(patientId));
        RoomId = Guard.Against.NegativeOrZero(roomId, nameof(roomId));
        TimeRange = Guard.Against.Null(timeRange, nameof(timeRange));
        Title = Guard.Against.NullOrEmpty(title, nameof(title));
        DateTimeConfirmed = dateTimeConfirmed;
    }

    private Appointment() { } // EF required

    public Guid ScheduleId { get; private set; }
    public int ClientId { get; private set; }
    public int PatientId { get; private set; }
    public int RoomId { get; private set; }
    public int DoctorId { get; private set; }
    public int AppointmentTypeId { get; private set; }

    public DateTimeOffsetRange TimeRange { get; private set; }
    public string Title { get; private set; }
    public DateTimeOffset? DateTimeConfirmed { get; set; }
    public bool IsPotentiallyConflicting { get; set; }

    public void UpdateRoom(int newRoomId)
    {
        Guard.Against.NegativeOrZero(newRoomId, nameof(newRoomId));
        if (newRoomId == RoomId) return;

        RoomId = newRoomId;

        var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
        Events.Add(appointmentUpdatedEvent);
    }

    public void UpdateDoctor(int newDoctorId)
    {
        Guard.Against.NegativeOrZero(newDoctorId, nameof(newDoctorId));
        if (newDoctorId == DoctorId) return;

        DoctorId = newDoctorId;

        var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
        Events.Add(appointmentUpdatedEvent);
    }

    public void UpdateStartTime(
        DateTimeOffset newStartTime,
        Action scheduleHandler)
    {
        if (newStartTime == TimeRange.Start) return;

        TimeRange = new DateTimeOffsetRange(newStartTime, TimeSpan.FromMinutes(TimeRange.DurationInMinutes()));

        scheduleHandler?.Invoke();

        var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
        Events.Add(appointmentUpdatedEvent);
    }

    public void UpdateTitle(string newTitle)
    {
        if (newTitle == Title) return;

        Title = newTitle;

        var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
        Events.Add(appointmentUpdatedEvent);
    }

    public void UpdateAppointmentType(
        AppointmentType appointmentType,
        Action scheduleHandler)
    {
        Guard.Against.Null(appointmentType, nameof(appointmentType));
        if (AppointmentTypeId == appointmentType.Id) return;

        AppointmentTypeId = appointmentType.Id;
        TimeRange = TimeRange.NewEnd(TimeRange.Start.AddMinutes(appointmentType.Duration));

        scheduleHandler?.Invoke();

        var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);
        Events.Add(appointmentUpdatedEvent);
    }

    public void Confirm(DateTimeOffset dateConfirmed)
    {
        if (DateTimeConfirmed.HasValue) return; // no need to reconfirm

        DateTimeConfirmed = dateConfirmed;

        var appointmentConfirmedEvent = new AppointmentConfirmedEvent(this);
        Events.Add(appointmentConfirmedEvent);
    }
}
```

This minimal implementation of the `Doctor` type satisfies the scheduling `Bounded Context`. It is no more than a reference entity. `Doctor` and other similar types, `Patient`, `Room`, etc., are all organized into this folder called `SyncedAggregates`.

![image](https://user-images.githubusercontent.com/34960418/211829814-9c1392ee-847e-444e-9852-7d44771f9226.png)

```csharp
public class Doctor : BaseEntity<int>, IAggregateRoot
{
    public Doctor(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; private set; }

    public override string ToString()
    {
        return Name.ToString();
    }
}
```

## Synchronizing Data Across Bounded Contexts

`AppointmentType`, `Client`, `Doctor`, `Patient`, and `Room` are all reference entities. We were doing their maintenance elsewhere, so they are not adding any unneeded complexity to the `FrontDesk` application, and they are just read-only. So we never had to create or modify them.

And we are using the `ints` created by the database when we persisted these with the CRUD context in a different application, but they are still entities here.

The `Clinic Management` bounded context is responsible for updating these types. When changes are made, application events are published by `Clinic Management`, and the `FrontDesk` bounded context subscribes to those events and updates its copies of the entities.

Message queues are one way to share data across bounded contexts.

![image](https://user-images.githubusercontent.com/34960418/211857199-cffe835f-3ed1-4fe7-a758-22126676c566.png)

**Eventual Consistency** - Systems do not need to be strictly synchronized, but the changes will eventually get to their destination.


## Key Terms from this Module

- **Anemic Domain Model** - Model with classes focused on state management. Good for **CRUD**.
- **Rich Domain Model** - Model with logic focused on behavior, not just state. Preferred for **DDD**. Help us solve complex problems.
- **Entity** - A mutable class with an **identity** (not tied to its property values) used for tracking and persistence. Driven by their **identity** value.





