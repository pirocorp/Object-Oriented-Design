**Domain-Driven Design is a way to design a subset of the objects in the system.**

In **DDD**, the main goal is to establish **common language** with the **business experts**. The separation of the domain from rest of the application code is just a side effect of this main goal. It also has some say about the design of classes as entities and aggregates, but that is only within the domain itself. It has nothing to say about design outside the domain code.

**Clean**/**Hexagonal**/**Onion** (or CHO in short) architecture, is an architectural pattern for a system, whereas **DDD** is a way to design a subset of the objects in the system. The two can exist without each other, so neither is a subset of the other. If you were to use them together - then as a whole the **part that is designed using DDD would be a subset** of the entire system.


# Table of Contents

- [Introducing Domain-Driven Design](Introducing%20Domain-Driven%20Design.md)
- [Modeling Problems in Software](Modeling%20Problems%20in%20Software.md)
- [Elements of a Domain Model: Entities](Elements%20of%20a%20Domain%20Model%20Entities.md)
- [Elements of a Domain Model: Value Objects & Services](Elements%20of%20a%20Domain%20Model%20Value%20Objects%20And%20Services.md)
- [Applying Aggregates and Associations](Applying%20Aggregates%20and%20Associations.md)
- [Working with Repositories](Working%20with%20Repositories.md)
- [Adding in Domain Events and Anti-corruption Layers](Adding%20in%20Domain%20Events%20and%20Anti-corruption%20Layers.md)
- [Message Queues](Message%20Queues.md)
- [Considerations](Considerations.md)


# Patterns Of DDD

- [Value Object](Value%20Object)
- [Repository](/06.%20Repositories)
- [Specification](/07.%20Specification)
- [Domain Events](Domain%20Events)

# Resources

- [Martin Fowler](https://martinfowler.com/)
- [Vaughn Vernon](https://vaughnvernon.com/)
- [Eric Evans](https://www.domainlanguage.com/)
- [Event storming via Alberto Brandolini](https://www.eventstorming.com/)
- [Event Modeling via Adam Dymitruk](https://www.eventmodeling.org/)
- [Pluralsight DDD Fundamentals Sample](https://github.com/ardalis/pluralsight-ddd-fundamentals)
- [Domain-Driven Design: The First 15 Years (Free book)](https://leanpub.com/ddd_first_15_years)
- [Anemic Domain Model](https://www.martinfowler.com/bliki/AnemicDomainModel.html)
- [Services in Domain-Driven Design](https://lostechies.com/jimmybogard/2008/08/21/services-in-domain-driven-design/)
- [Specification Pattern Base Class](https://github.com/ardalis/Specification)
- [Avoid In-Memory Databases for Tests](jimmybogard.com/avoid-in-memory-databases-for-tests/)
- [Bus or Queue](https://ardalis.com/bus-or-queue/)

## Conferences on DDD

- [Domain Driven Design Europe](https://www.youtube.com/@ddd_eu)
- [KanDDDinsky](https://www.youtube.com/@KanDDDinsky)
- [Explore DDD](https://www.youtube.com/@ExploreDDD)
- [Virtual DDD Meetup](https://www.youtube.com/@virtualdomain-drivendesign2670)
- [Domain-Driven Design Europe](https://www.youtube.com/@ddd_eu)
