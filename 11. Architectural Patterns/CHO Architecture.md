# CHO Architecture

## Overview

In **Clean**/**Hexagonal**/**Onion** (or **CHO** in short) architecture, the goal of this decoupling is testability and modularity with intended effect being that the "core" of our software can be reasoned about in isolation from rest of the world.

You use **CHO** architecture to design the whole structure of the system, with the "**domain core**" being isolated in it's separate modules. And then you use **DDD** to design this domain core in collaboration with domain experts and possibly by using **DDD** concepts like **Entites** and **Aggregates**.

**CHO** is an architectural pattern for a system, whereas DDD is a way to design a subset of the objects in the system. The two can exist without eachother, so neither is a subset of the other. If you were to use them together - then as a whole the part that is designed using DDD would be a subset of the entire system.


## Description

**CHO Architecture** leads to more maintainable applications since it emphasizes separation of concerns throughout the system. I must set the context for the use of this architecture before proceeding. This architecture is not appropriate for small websites. It is appropriate for long-lived business applications as well as applications with complex behavior. It emphasizes the use of interfaces for behavior contracts, and it forces the externalization of infrastructure. The diagram you see here is a representation of traditional layered architecture. This is the basic architecture I see most frequently used.  

![image](https://user-images.githubusercontent.com/34960418/205276899-ea34738a-38d5-46bd-b729-653395a0135c.png)

Each subsequent layer depends on the layers beneath it, and then every layer normally will depend on some common infrastructure and utility services. The big drawback to this top-down layered architecture is the coupling that it creates. Each layer is coupled to the layers below it, and each layer is often coupled to various infrastructure concerns. However, without coupling, our systems wouldn’t do anything useful, but this architecture creates unnecessary coupling.

The biggest offender (and most common) is the coupling of UI and business logic to data access. es, UI is coupled to data access with this approach. Transitive dependencies are still dependencies. The UI can’t function if business logic isn’t there. Business logic can’t function if data access isn’t there. I’m intentionally ignoring infrastructure here because this typically varies from system to system. If coupling prevents easily upgrading parts of the system, then the business has no choice but to let the system fall behind into a state of disrepair. This is how legacy systems become stale, and eventually they are rewritten.

The diagram depicts the **Onion (CHO) Architecture**. The main premise is that it controls coupling. The fundamental rule is that all code can depend on layers more central, but code cannot depend on layers further out from the core. In other words, **all coupling is toward the center**. This architecture is unashamedly biased toward object-oriented programming, and it puts objects before all others.

![image](https://user-images.githubusercontent.com/34960418/205277792-cdb68bb2-ffe6-41c0-900d-364469c2eb64.png)

In the very center we see the **Domain Model**, which represents the state and behavior combination that models truth for the organization. Around the **Domain Model** are other layers with more behavior. The number of layers in the application core will vary, but remember that the **Domain Model is the very center**, and since all coupling is toward the center, **the Domain Model is only coupled to itself**. The **first layer** around the **Domain Model** is typically where we would find interfaces that provide object saving and retrieving behavior, called **repository interfaces**. **The object saving behavior is not in the application core**, however, because it typically involves a database. **Only the interface is in the application core**. Out **on the edges** we see **UI**, **Infrastructure**, and **Tests**. **The outer layer is reserved for things that change often**. **These things should be intentionally isolated from the application core**. Out **on the edge**, we would find a **class** that **implements** a **repository interface**. This class is **coupled to a particular method of data access**, **and that is why it resides outside the application core**. This class implements the repository interface and is thereby coupled to it.

The Onion Architecture relies heavily on the [Dependency Inversion principle](https://en.wikipedia.org/wiki/Dependency_inversion_principle). The application core needs implementation of core interfaces, and if those implementing classes reside at the edges of the application, we need some mechanism for injecting that code at runtime so the application can do something useful.

**The database is not the center. It is external.** Externalizing the database can be quite a change for some people used to thinking about applications as “database applications”. With CHO Architecture, there are no database applications. There are applications that might use a database as a storage service but only though some external infrastructure code that implements an interface which makes sense to the application core. Decoupling the application from the database, file system, etc, lowers the cost of maintenance for the life of the application.


## CHO vs N-layer

Compare the **CHO Architecture** with traditional layered architecture. I will flatten the **CHO Architecture** to see what it looks like compared to traditional layered architecture, and I will force the layered architecture into an onion. Whereas the shape can be either, the structure of the actual application is radically different from what is commonly known and accepted.

**Traditional layered architecture** can look somewhat like the bottom diagram. Each layer communicates with the layer below it. The UI talks to business logic, but it does not talk directly to data access, services, etc. The layering approach does call out the need to keep certain categories of code out of the UI. The big downfall is that business logic ends up coupled to infrastructure concerns. Data Access, I/O, and Web Services are all infrastructure. **Infrastructure is any code that is a commodity and does not give your application a competitive advantage**. This code is most likely to change frequently as the application goes through years of maintenance.

![image](https://user-images.githubusercontent.com/34960418/205282017-74f8becf-e419-44f7-987e-a1e694f5898b.png)


Let’s review **CHO Architecture**. The object model is in the center with supporting business logic around it. The direction of coupling is toward the center. The big difference is that any outer layer can directly call any inner layer. With traditionally layered architecture, a layer can only call the layer directly beneath it. **This is one of the key points that makes CHO Architecture different from traditional layered architecture**. Infrastructure is pushed out to the edges where no business logic code couples to it. The code that interacts with the database will implement interfaces in the application core. The application core is coupled to those interfaces but not the actual data access code. In this way, we can change code in any outer layer without affecting the application core. We include tests because any long-lived application needs tests. Tests sit at the outskirts because the application core doesn’t couple to them, but the tests are coupled to the application core. We could also have another layer of tests around the entire outside when we test the UI and infrastructure code.

![image](https://user-images.githubusercontent.com/34960418/205283045-dd5d1638-139c-4584-8d33-078e8e9ad616.png)

This approach to application architecture ensures that the application core doesn’t have to change as: the UI changes, data access changes, web service and messaging infrastructure changes, I/O techniques change.

A diagram which attempts to show what **CHO Architecture** would look like when **represented** as a **traditionally layered architecture**. The big difference is that **Data Access is a top layer** along with UI, I/O, etc. Another key difference is that the layers above can use any layer beneath them, not just the layer immediately beneath. Also, business logic is coupled to the object model but not to infrastructure

![image](https://user-images.githubusercontent.com/34960418/205283436-99cdb9ce-e276-4e2f-838d-dd77d7a5fada.png)

**Attempted representation of traditional layered architecture using concentric circles**. Black lines around the layers denote that each outer layer only talks to the layer immediately toward the center. The big kicker here is that we clearly see the application is built around data access and other infrastructure. Because the application has this coupling, when data access, web services, etc. change, the business logic layer will have to change. **The world view difference is how to handle infrastructure**. **Traditional layered architecture couples directly to it**. **CHO Architecture pushes it off to the side and defines abstractions (interfaces) to depend on**. **Then the infrastructure code also depends on these abstractions (interfaces)**. **Depending on abstractions is an old principle, but the CHO Architecture puts that concepts right up front**. 

![image](https://user-images.githubusercontent.com/34960418/205283859-3baffd5b-5cb5-4396-b359-dbeae985122b.png)


## Key tenets of CHO Architecture:

- The application is built around an independent object model
- Inner layers define interfaces. Outer layers implement interfaces
- Direction of coupling is toward the center
- All application core code can be compiled and run separate from infrastructure

**CHO architecture** works well with and without **DDD patterns**. It works well with **CQRS**, forms over data, and **DDD**. It is merely an **architectural pattern where the core object model is represented in a way that does not accept dependencies on less stable code**.


# Example

Simple Clean Architecture [Example](https://github.com/pirocorp/Simple-Clean-Architecture/tree/simple-clean-architecture-no-cqrs-no-ddd).
