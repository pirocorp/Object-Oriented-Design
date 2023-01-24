# Considering Microservices

Microservices Basic Tenets

- Self-contained
- No dependency on other microservices
- Independently deployable
- Changing internals should not break communications

Each **Microservice** should have a boundary around it, and within that boundary should focus on a specific set of behaviors that fits its model. Each **Microservice** can be considered its **Bounded Context**, and it has its terminology or even language for how it is designed.

It is not unusual for teams to treat individual **Microservices** like **Bounded Contexts** with their own **Ubiquitous Language** and everything else that goes along with the **Bounded Contexts**. **Bounded context is not necessarily equal to a microservice**

![image](https://user-images.githubusercontent.com/34960418/214265199-cc99422d-aa52-4c1e-9dad-e67ec96c420c.png)

- Heuristic #1 Decompose to **Bounded Contexts** - Do not implement conflicting models in the same service. Always decompose to **Bounded Contexts**
- Heuristic #2 Only decompose the **Bounded Contexts** further if you got a good reason to do so.
  > First Law of Distributed Object Design: "Don't distribute your objects."
  
  Martin Fowler
  
- Heuristic #3 Buy/Adopt **Generic Subdomains** - it is beneficial to abstract its model and implementation details by implementing a thin **Anti-Corruption-Layer** that will be used as a proxy between that product and your system. This will make them well-behaved microservices.
  ```mermaid
    flowchart LR
    id1[Your System] <--> id2[Anti-Corruption-Layer] <--> id3[3rd party product]
  ```

- Heuristic #4 **Core Subdomains** - Don't Rush - Adhere to the subdomain's boundaries. Decompose further only when you acquire domain knowledge. Making changes across wrong boundaries, it's both painful, and the complexity of each change will be orders of magnitude higher.
- Heuristic #5 Supporting Subdomains - Safe to decompose beyond the subdomain's boundaries. 
- Heuristic #6 Evaluate Consistency Requirements
  - Concurency Control? - Same Service
    ```mermaid
      flowchart TB
      subgraph ide1 [Service A]
        direction BT
        id2((Method A)) --> id1[(Database)]
        id3((Method B)) --> id1[(Database)]
      end
    ```
  - Read last write? - Two services, synchronous communication
    ```mermaid
      flowchart LR
        subgraph ide1 [Service A]
          id2((Method A))
        end
        
        subgraph ide2 [Service B]
          id3((Method B))
        end
      
        ide1 -- "Sync call" --> ide2
    ```
  - Eventual consistency? - Two services, asynchronous communication - default way of integrating microservices.
    ```mermaid
      flowchart LR
      subgraph ide1 [Service A]
        id2((Method A))
      end
      subgraph ide2 [Service B]
        id3((Method B))
      end
      
      subgraph ide3 [Asynchronous Communication]
        id4{{"✉️"}}
      end
      
      ide1 --> ide3 --> ide2
    ```
- Heuristic #7 Public / Private Events
  - Separate events on public and private - this minimizes the services front door. It also freed you to change the implementation details without affecting the integrating systems (clients that integrate with your service).
  ```mermaid
  flowchart LR
    id1[Service A] -- "✉️" -->  id2{{"Event Type 1"}} --> id9("Public event types (Public interface)")
    id1[Service A] -- "✉️" -->  id3{{"Event Type 2"}} --> id9("Public event types (Public interface)")
    id1[Service A] -- "✉️" -->  id4{{"Event Type 3"}} --> id9("Public event types (Public interface)")
    id1[Service A] -- "✉️" -->  id5{{"Event Type 4"}} --> id10("Private event types (Implementation details)")
    id1[Service A] -- "✉️" -->  id6{{"Event Type 5"}} --> id10("Private event types (Implementation details)")
    id1[Service A] -- "✉️" -->  id7{{"Event Type 6"}} --> id10("Private event types (Implementation details)")
    id1[Service A] -- "✉️" -->  id8{{"Event Type 1000"}} --> id10("Private event types (Implementation details)")
  ```
  - Compressing the public events
  ```mermaid
  flowchart LR
    id1[Service A] -- "✉️" -->  id2{{"EmailChanged"}} -->  id10("Private event types (Implementation details)")
    id1[Service A] -- "✉️" -->  id3{{"PhoneNumberChanged"}} -->  id10("Private event types (Implementation details)")
    id1[Service A] -- "✉️" -->  id4{{"AddressChanged"}} -->  id10("Private event types (Implementation details)")
    id1[Service A] -- "✉️" -->  id5{{"ContactDetailsChanged"}} --> id9("Public event type (Public interface)")
  ```

# Considering the UI in the Domain Design

Is it an anti-pattern to think about the UI when we are focused on the domain?
**- NO!**

The demands of the user interface can impact parts of your application.

> Most likely I’m learning stuff [with UI sketching] that affects my story and scenario

Jimmy Nilsson


# Modeling with Event Storming and Other Techniques

- Event Storming
- Event Modeling
- Domain Storytelling
- Domain Storytelling Modeler
- Bounded Context Canvas
- Using [Miro.com](miro.com) for a Model Desiggn

# Fallacy of Perfectionism

**Domain-Driven Design provides guidance, not rules.**

> There’s something about DDD that brings out the perfectionist in people… they say, this model’s not really good enough…and basically churn and churn. I’m here to say, no model is going to be perfect.
>
> We need to know what we’re doing with this thing, the scenarios we’re trying to address. We want a model that helps us do that, that makes it easier to make software that solves those problems. That’s it.

Eric Evans


