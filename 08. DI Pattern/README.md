# Dependency Injection design pattern

Dependency Injection means providing the objects that some class needs (its dependencies) from the outside, instead of having it construct them itself.

In C#, we most typically use the constructor injection - so the dependency is injected to a class via its constructor. It is also possible to inject dependency via a setter, but this is much less popular (as, in general, having a public setter is a risky business).

Before we mentioned that classes should not be responsible for creating their dependencies. Well, who should be responsible for it, then? Most typically we have two places where we construct objects, depending on our needs:

- The creation of objects is not done manually, but with Dependency Injection frameworks. They are mechanisms that automatically create dependencies and inject them into objects that need them. Dependency Injection frameworks are configurable, so we can decide what concrete types will be injected into objects. They can also be configured to reuse one instance of some type or to create separate instances for each object that needs them. Some of the popular Dependency Injection frameworks in C# are Autofac or Ninject.

- If we are not sure what objects exactly we need (a concrete type may depend on some parameter or configuration provided at runtime), or whether we will need them at all, we can use a factory.