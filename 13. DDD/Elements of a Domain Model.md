# Elements of a Domain Model

## Entity & Context are Common Software Terms

![image](https://user-images.githubusercontent.com/34960418/211572523-4a4d4eb6-aa30-49d6-a35d-4db043007b31.png)


## Focusing on the Domain

Shift Thinking from DB-Driven to Domain-Driven. From Designing software based on data storage needs to Designing software based on business needs.

> [The Domain Layer is] responsible for representing **concepts of the business, information about the business situation, and business rules**. State that reflects the business situation is controlled and used here, even though the technical details of storing it are delegated to the infrastructure. **This layer is the heart of business software**.

Eric Evans

### Focus on Behaviors, Not Attributes. 

In the typical data-driven app, we focus on properties. Sometimes, we are all about editing properties and the state of our objects. However, when we are modeling the domain, we need to focus on the behaviors of that domain, not simply on changing the state of objects.


![image](https://user-images.githubusercontent.com/34960418/211576996-8e1d2a02-d791-43ab-adec-78d0f5d27379.png)


### Identifying Events Leads to Understanding Behaviors

![image](https://user-images.githubusercontent.com/34960418/211577440-5c610fca-f196-44f0-8873-20d453ebe580.png)


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

![image](https://user-images.githubusercontent.com/34960418/211597475-f9671ada-f12b-4e85-9008-e42398366f95.png)

> Many objects are not fundamentally defined by their attributes, but rather by a thread of continuity and identity.

Eric Evans

Entities Have Identity And Are Mutable. An Entity is something that we can be able to **track**, **locate**, **retrieve** and **store**. And we do that with an identity key. Its properties may change, so we cant use its properties to identify the object.

![image](https://user-images.githubusercontent.com/34960418/211599421-5846d559-6d80-4ac4-818e-93eff2a34644.png)

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


Example of Entity designed using Domain Driven Design

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

> Single Responsibility is a good principle to apply to entities. It points you toward the sort of responsibility that an entity should retain. Anything that doesn't fall in that category we ought to put somewhere else.
> 
> Their core responsibility is identity and life-cycle

Eric Evans
