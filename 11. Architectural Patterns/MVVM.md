# MVVM

![image](https://user-images.githubusercontent.com/34960418/204833851-605b7668-4c03-4389-8bc9-ad59ed49cdc7.png)

**Model–view–viewmodel** (**MVVM**) is an architectural pattern in computer software that facilitates the separation of the development of the graphical user interface (GUI; the view)—be it via a markup language or GUI code—from the development of the business logic or back-end logic (the **model**) such that the view is not dependent upon any specific model platform.

The **viewmodel** of MVVM is a value converter, meaning it is responsible for exposing (converting) the data objects from the model in such a way they can be easily managed and presented. In this respect, the viewmodel is more model than view, and handles most (if not all) of the view's display logic. The viewmodel may implement a mediator pattern, organizing access to the back-end logic around the set of use cases supported by the view.

It was invented by Microsoft architects Ken Cooper and Ted Peters specifically to simplify **event-driven programming** of user interfaces. The pattern was incorporated into the Windows Presentation Foundation (WPF).

Model–view–viewmodel is also referred to as model–view–binder, especially in implementations not involving the .NET platform.


# Components 

## Model

Model refers either to a domain model, which represents real state content (an object-oriented approach), or to the data access layer, which represents content (a data-centric approach).


## View

As in the [model–view–controller (MVC)](MVC.md) and [model–view–presenter (MVP)](MVP.md) patterns, the view is the structure, layout, and appearance of what a user sees on the screen. It displays a representation of the model and receives the user's interaction with the view (mouse clicks, keyboard input, screen tap gestures, etc.), and it forwards the handling of these to the view model via the data binding (properties, event callbacks, etc.) that is defined to link the view and view model.


## View model

The view model is an abstraction of the view exposing public properties and commands. Instead of the controller of the MVC pattern, or the presenter of the MVP pattern, MVVM has a binder, which automates communication between the view and its bound properties in the view model. **The view model has been described as a state of the data in the model**.

The main difference between the view model and the Presenter in the MVP pattern is that the presenter has a reference to a view, whereas the view model does not. Instead, a view directly binds to properties on the view model to send and receive updates. To function efficiently, this requires a binding technology or generating boilerplate code to do the binding.


## Binder

Declarative data and command-binding are implicit in the MVVM pattern. In the Microsoft solution stack, the binder is a markup language called XAML. The binder frees the developer from being obliged to write boiler-plate logic to synchronize the view model and view. When implemented outside of the Microsoft stack, the presence of a declarative data binding technology is what makes this pattern possible, and without a binder, one would typically use MVP or MVC instead and have to write more boilerplate (or generate it with some other tool).


# Rationale

MVVM was designed to remove virtually all GUI code ("code-behind") from the view layer, by using data binding functions in WPF (Windows Presentation Foundation) to better facilitate the separation of view layer development from the rest of the pattern. 

The MVVM pattern attempts to gain both advantages of separation of functional development provided by MVC, while leveraging the advantages of data bindings and the framework by binding data as close to the pure application model as possible. It uses the binder, view model, and any business layers' data-checking features to validate incoming data. The result is that the model and framework drive as much of the operations as possible, eliminating or minimizing application logic which directly manipulates the view (e.g., code-behind).


# Example

[.NET MAUI with Simple MVVM Architecture](https://github.com/pirocorp/MAUI-Playground/tree/main/MVVM%20Architecture)
