# Introducing Domain-Driven Design

## Why DDD?

Value Proposition of DDD

- Principles and patterns to **solve difficult problems**
- History of **success** with complex projects
- Aligns with practices from developers **experience**
- **Clear, readable, testable code** that represents the domain


## What does a DDD solution look like?
```mermaid
  flowchart 
  subgraph ide1 [Solve Problems]
    direction BT
    id1[Write Code]
    id2[Design System]
    id3[Understanding client needs]
    id4[Full partnership]
    
    id4 --> id3 --> id2 --> id1
  end
```

## What is Domain-Driven Design?

Domain-Driven Design is an approach to software development that centers the development on programming a domain model that has a rich understanding of the processes and rules of a domain. The name comes from a 2003 book by Eric Evans that describes the approach through a catalog of patterns. Since then a community of practitioners have further developed the ideas, spawning various other books and training courses. The approach is particularly suited to complex domains, where a lot of often-messy logic needs to be organized.

Eric Evans's great contribution to this, was developing a vocabulary to talk about this approach, identifying key conceptual elements that went beyond the various modeling notations that dominated the discussion at the time. At the heart of this was the idea that to develop software for a complex domain, we need to build Ubiquitous Language that embeds domain terminology into the software systems that we build.


### Gaining a High-Level Understanding of DDD 

- Better Interaction with domain experts
  > You really need to cultivate your ability to communicate with business people to free up people's creative modeling.  
  
  Eric Evans

- Model a **single subdomain** at a time
  - Divide and Conquer - By separating the problem into separate subdomains, we can tackle each problem independently. We are making the problem much easier to solve.
    - Purchase materials - `tasks`, `ubiquitous language`, `unique problems`
    - Engineering - `tasks`, `ubiquitous language`, `unique problems`
    - Manage employees - `tasks`, `ubiquitous language`, `unique problems`
    - Marketing - `tasks`, `ubiquitous language`, `unique problems`
    - Sales - `tasks`, `ubiquitous language`, `unique problems`
  - Modeling - How you decipher and design each subdomain.
- Implementation of subdomains
  - **Separation of Concerns** - plays an important role in implementing subdomains.


## Goals of DDD

- DDD aims to **tackle business complexity**, not technical complexity. 
  > While Domain-Driven Design provides many technical benefits, such as maintainability, it should be applied **only to complex domains** where the model and the linguistic processes **provide clear benefits** in the **communication of complex information**, and in the formulation of a **common understanding of the domain**.

  Eric Evans, Domain-Driven Design


## Benefits and potential drawbacks of DDD

### Benefits of Domain-Driven Design

- Flexible
- Customer’s vision/perspective of the problem
- Path through a very complex problem
- Well-organized and easily tested code
- Business logic lives in one place
- Many great patterns to leverage

### Drawbacks of Domain-Driven Design

- Be Prepared for Time and Effort
  - Discuss and model the problem with domain experts
  - Isolate domain logic from other parts of application
- Be Prepared for a Learning Curve
  - New principles
  - New patterns
  - New processes
- Be Thoughtful About Possible Overuse - DDD is for handling **complexity in business problems**
  - Not just CRUD or data-driven applications.
  - Not just technical complexity without business domain complexity.
- Requires Team and Business Buy-In


## Inspecting a Mind Map of Domain-Driven Design

![image](https://user-images.githubusercontent.com/34960418/211310896-a1778527-954d-4e62-8037-95935b4ca65b.png)

- Modeling - Modeling is an intense examination of the problem space. 
  - Core Domain - The key is working with the subject matter experts to identify the core domain and other sub-domains that will be tackled.
  - Bounded Contexts - You focus on modeling a particular sub-domain in each of these bounded contexts.
  - Generic Subdomains - The model also has notes for each element, such as avoiding overinvesting in Generic Subdomains. That can be something like the credit card verification service you can use rather than building yourself.

![image](https://user-images.githubusercontent.com/34960418/211311084-23c46cfe-116a-4f7c-b69b-2ca256b2a818.png)

- Software Implementation - As a result of modeling the bounded context, you'll identify entities, value objects, aggregates, domain events, repositories, and more and how they interact with each other.
  - **Entities**
  - **Value Objects**
  - **Domain Events**
  - **Aggregates**
  - **Repositories**

![image](https://user-images.githubusercontent.com/34960418/211311186-01ceda12-53c9-4732-a54d-e8af88eee01b.png)

- Communication
  - **Ubiquitous Language** - to come up with terms that will be commonly used when discussing a particular sub-domain. And they most likely are terms coming from problem space, not the software world. They have to be agreed upon so that as discussions move forward, there is clarity and understanding created by the terminology used by team members.

![image](https://user-images.githubusercontent.com/34960418/211311270-ed649daa-5158-4565-95d3-53bb0667d1a8.png)

- Development Process
  - **Anti-corruption Layer** - Anti-corruption layer allows sub-domains to communicate with one another from behind their boundaries.
  - Separate Ways - The model also has notes for each element, such as free teams to go separate ways. This is something that can be accomplished once you identify the boundaries of each subdomain.
  
![image](https://user-images.githubusercontent.com/34960418/211311377-db0035b1-e4a9-4b41-97df-6bdc9f7c3e57.png)


## Exploring the Sample App’s High-Level Structure

![image](https://user-images.githubusercontent.com/34960418/211518407-61ed5ede-ab62-4597-b320-fb1c4904a192.png)

![image](https://user-images.githubusercontent.com/34960418/211518589-bb161b49-9a94-4432-addc-fca038568a63.png)

