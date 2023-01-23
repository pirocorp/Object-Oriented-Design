# Considering Microservices

Microservices Basic Tenets

- Self-contained
- No dependency on other microservices
- Independently deployable
- Changing internals should not break communications

Each **Microservice** should have a boundary around it, and within that boundary should focus on a specific set of behaviors that fits its model. Each **Microservice** can be considered its **Bounded Context**, and it has its terminology or even language for how it is designed.

It is not unusual for teams to treat individual **Microservices** like **Bounded Contexts** with their own **Ubiquitous Language** and everything else that goes along with the **Bounded Contexts**. **Bounded context is not necessarily equal to a microservice**


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


