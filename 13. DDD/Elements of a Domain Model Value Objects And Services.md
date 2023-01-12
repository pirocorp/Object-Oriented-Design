# Elements of a Domain Model: Value Objects & Services

**Value Objects** are objects defined **by their value**, **not by identity**. Measures quantify or describe a thing in the domain. Its identity is based on the composition of values of all of its properties. Because the properties define the **Value Object**, it should be immutable (i.e., you shouldn't be able to change any of its properties once you create one of these objects. Instead, you create another instance with the new values). 

If you need to compare two **Value Objects** to determine if they are equal, you should do so by comparing all the values. Value objects may have methods and behavior, but they should never have side effects. Any method on the **Value Objects** should compute things. They should never change the state of the **Value Objects**. New **Value Objects** should be returned if a new value is needed.

Make sure to distinguish the **Value Objects** pattern from C# support for value and reference types. Custom **ValueTypes** are defined with structs, and **Reference Types** are defined with classes. In **DDD**, both **DDD Entities** and **DDD Value Objects** are defined as classes.

## Recognizing Commonly Used Value Objects

- **String** is a **Value Object**.
  - String Methods Respect Immutability
    - Replace (StringA, StringB) - Returns a new string in which all occurrences StringA in the current instance are replaced with StringB.
    - ToUpper() - Returns a copy of this string converted to uppercase.
    - ToLower() - Returns a copy of this string converted to lowercase.
- Money is a Great candidate for a **Value Object**. 
- Dates are a classic value object, and they have all kinds of logic.

### [Whole Value](http://fit.c2.com/wiki.cgi?WholeValue).

A whole value is a quantity used to describe things in a domain. Whole values are not themselves things, but measures of things. As such they do not have an identity of consequence.

For example, we might say a company is worth 50,000,000 dollars. Some thing, the company, its stock, or a proposed investment, is being measured. The thing is a real object while the 50,000,000 dollars is a value, a property of the thing.

In object oriented computing it is commonplace and good practice to model values as objects. Key to this is defining a notion of equality that is independent of object identity. Another key, and the point of the WholeValue pattern, is that the objects model the whole property being measured, not just some part of it. In the example above the whole value is 50,000,000 dollars, not just 50,000,000 and not just "dollars".

If I know a field will contain a whole value or nil, I do not have to be concerned with any conditions outside those modeled by the whole value once I have established that it is not nil. The whole value pattern argues that whole values should be entered in single fields and checked to be well formed in one place.

Worth is a **Value Object**

![image](https://user-images.githubusercontent.com/34960418/212072662-88b8f086-4990-41f9-a569-f850b7abe265.png)

GeoCoordinate are another example of whole value.

DateTimeRange as **Value Object**.

![image](https://user-images.githubusercontent.com/34960418/212073850-9f92fcea-8ef7-4649-981e-43de22b268b5.png)

> It may surprise you to learn that we should strive to model using Value Objects instead of Entities wherever possible. Even when a domain concept must be modeled as an Entity, the Entity’s design should be biased toward serving as a value container rather than a child Entity container.

Vaughn Vernon – Implementing Domain Driven Design


## When Considering Domain Objects

Our Instinct:
  1. Probably an entity
  2. Maybe a value object

Vaughn Vernon’s guidance:
  1. Is this a value object?
  2. Otherwise, an entity



Value Objects Can Be Used for Identifiers 

`ClientIdValueObject.cs`

```csharp
public class ClientId
{
    public ClientId()
    {
        Id = Guid.NewGuid();
    }
  
    public ClientId(Guid id)
    {
        Id = id;
    }
  
    public Guid Id { get; private set; }
  
    [Equality and Hash override code]
}
```

Value Objects Can Be Used for Identifiers

`Client.cs`

```csharp
public class Client
{
    public ClientIdValueObject Id {get; set;}
}

// or

public class Client : BaseEntity<ClientIdValueObject>
{
    // Id property provided by base type
}
```


Explicit ID Value Objects Instead of Ints/GUIDs - Helps to Avoid Errors in Passed Parameters

`Client.cs`

```csharp
public class Client : BaseEntity<ClientIdValueObject>
{
    . . .
}
```

`SomeService.cs`

```csharp
public class SomeService
{
    public void CreateAppointmentFor(
        ClientIdValueObject clientId,
        PatientIdValueObject patientId)
    {
        . . .
    }
}
```

> I think that value objects are a really good place to put methods and logic…because we can do our reasoning without side effects and identity, all those things that make logic tricky. We can put functions on those value objects and do the pure reasoning there.

Eric Evans


## Implementing Value Objects in Code

- The state of a value object should not be changed once it has been created.
- Generic logic makes sense in value objects.
- It’s easier to test logic that’s in a value object.
- Entity becomes an orchestrator.


![image](https://user-images.githubusercontent.com/34960418/212106798-524376d0-6c3c-4cb1-bbe8-522fd4296473.png)

> A higher level of abstraction in entities can lead you to a more precise ubiquitous language.

Eric Evans

```DateTimeRange.cs```

```csharp
public class DateTimeRange : ValueObject
{   
    public DateTimeRange(DateTime start, DateTime end)
    {
        // Ardalis.GuardClauses supports extensions with custom guards per project
        Guard.Against.OutOfRange(start, nameof(start), start, end);
        Start = start;
        End = end;
    }

    public DateTimeRange(DateTime start, TimeSpan duration)
        : this(start, start.Add(duration))
    {
    }
    
    public DateTime Start { get; private set; }
    
    public DateTime End { get; private set; }
    
    public DateTimeRange NewEnd(DateTime newEnd)
    {
        return new DateTimeRange(this.Start, newEnd);
    }
    
    public bool Overlaps(DateTimeRange dateTimeRange)
    {
        return this.Start < dateTimeRange.End && this.End > dateTimeRange.Start;
    }
    
    // used by base ValueObject type to implement equality
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}
```

