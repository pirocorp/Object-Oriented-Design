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
