# Onion Architecture

In **Clean**/**Hexagonal**/**Onion** (or **CHO** in short) architecture, the goal of this decoupling is testability and modularity with intended effect being that the "core" of our software can be reasoned about in isolation from rest of the world.

You use **CHO** architecture to design the whole structure of the system, with the "**domain core**" being isolated in it's separate modules. And then you use **DDD** to design this domain core in collaboration with domain experts and possibly by using **DDD** concepts like **Entites** and **Aggregates**.

**CHO** is an architectural pattern for a system, whereas DDD is a way to design a subset of the objects in the system. The two can exist without eachother, so neither is a subset of the other. If you were to use them together - then as a whole the part that is designed using DDD would be a subset of the entire system.


**CHO Architecture** leads to more maintainable applications since it emphasizes separation of concerns throughout the system. I must set the context for the use of this architecture before proceeding. This architecture is not appropriate for small websites. It is appropriate for long-lived business applications as well as applications with complex behavior. It emphasizes the use of interfaces for behavior contracts, and it forces the externalization of infrastructure. The diagram you see here is a representation of traditional layered architecture. This is the basic architecture I see most frequently used.  

![image](https://user-images.githubusercontent.com/34960418/205276899-ea34738a-38d5-46bd-b729-653395a0135c.png)

Each subsequent layer depends on the layers beneath it, and then every layer normally will depend on some common infrastructure and utility services. The big drawback to this top-down layered architecture is the coupling that it creates. Each layer is coupled to the layers below it, and each layer is often coupled to various infrastructure concerns. However, without coupling, our systems wouldn’t do anything useful, but this architecture creates unnecessary coupling.

The biggest offender (and most common) is the coupling of UI and business logic to data access. es, UI is coupled to data access with this approach. Transitive dependencies are still dependencies. The UI can’t function if business logic isn’t there. Business logic can’t function if data access isn’t there. I’m intentionally ignoring infrastructure here because this typically varies from system to system. If coupling prevents easily upgrading parts of the system, then the business has no choice but to let the system fall behind into a state of disrepair. This is how legacy systems become stale, and eventually they are rewritten.

The diagram depicts the **Onion (CHO) Architecture**. The main premise is that it controls coupling. The fundamental rule is that all code can depend on layers more central, but code cannot depend on layers further out from the core. In other words, **all coupling is toward the center**. This architecture is unashamedly biased toward object-oriented programming, and it puts objects before all others.

![image](https://user-images.githubusercontent.com/34960418/205277792-cdb68bb2-ffe6-41c0-900d-364469c2eb64.png)

In the very center we see the **Domain Model**, which represents the state and behavior combination that models truth for the organization. Around the **Domain Model** are other layers with more behavior. The number of layers in the application core will vary, but remember that the **Domain Model is the very center**, and since all coupling is toward the center, **the Domain Model is only coupled to itself**. The **first layer** around the **Domain Model** is typically where we would find interfaces that provide object saving and retrieving behavior, called **repository interfaces**. **The object saving behavior is not in the application core**, however, because it typically involves a database. **Only the interface is in the application core**. Out **on the edges** we see **UI**, **Infrastructure**, and **Tests**. **The outer layer is reserved for things that change often**. **These things should be intentionally isolated from the application core**. Out **on the edge**, we would find a **class** that **implements** a **repository interface**. This class is **coupled to a particular method of data access**, **and that is why it resides outside the application core**. This class implements the repository interface and is thereby coupled to it.

The Onion Architecture relies heavily on the [Dependency Inversion principle](https://en.wikipedia.org/wiki/Dependency_inversion_principle). The application core needs implementation of core interfaces, and if those implementing classes reside at the edges of the application, we need some mechanism for injecting that code at runtime so the application can do something useful.

**The database is not the center. It is external.** Externalizing the database can be quite a change for some people used to thinking about applications as “database applications”. With CHO Architecture, there are no database applications. There are applications that might use a database as a storage service but only though some external infrastructure code that implements an interface which makes sense to the application core. Decoupling the application from the database, file system, etc, lowers the cost of maintenance for the life of the application.



