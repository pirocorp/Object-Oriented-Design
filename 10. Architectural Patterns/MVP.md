# MVP

![image](https://user-images.githubusercontent.com/34960418/204837923-726da04e-78b9-4e47-b0f9-755c37526300.png)

**Model–view–presenter (MVP)** is a derivation of the model–view–controller (MVC) architectural pattern, and is used mostly for building user interfaces. In MVP, the presenter assumes the functionality of the "middle-man". In MVP, all presentation logic is pushed to the presenter. MVP is a user interface architectural pattern engineered to facilitate automated unit testing and improve the separation of concerns in presentation logic


# Components

Normally, the view implementation instantiates the concrete presenter object, providing a reference to itself. The following C# code demonstrates a simple view constructor, where ConcreteDomainPresenter implements the IDomainPresenter interface.

```csharp
public class DomainView : IDomainView
{
    private IDomainPresenter _domainPresenter;

    /// <summary>Constructor.</summary>
    public DomainView()
    {
        _domainPresenter = new ConcreteDomainPresenter(this);
    }
}
```

The degree of logic permitted in the view varies among different implementations. At one extreme, the view is entirely passive, forwarding all interaction operations to the presenter. In this formulation, when a user triggers an event method of the view, it does nothing but invoke a method of the presenter that has no parameters and no return value. The presenter then retrieves data from the view through methods defined by the view interface. Finally, the presenter operates on the model and updates the view with the results of the operation. 

Other versions of model-view-presenter allow some latitude with respect to which class handles a particular interaction, event, or command. This is often more suitable for web-based architectures, where the view, which executes on a client's browser, may be the best place to handle a particular interaction or command.

From a layering point of view, the presenter class might be considered as belonging to the application layer in a multilayered architecture system, but it can also be seen as a presenter layer of its own between the application layer and the user interface layer.

## Model

The model is an interface defining the data to be displayed or otherwise acted upon in the user interface.


## View

The view is a passive interface that displays data (the model) and routes user commands (events) to the presenter to act upon that data.


## Presenter

The presenter acts upon the model and the view. It retrieves data from repositories (the model), and formats it for display in the view.
