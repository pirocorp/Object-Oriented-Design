# N-Layer Architecture

In software engineering N-Layer architecture is a client–server architecture in which presentation, application processing and data management functions are physically separated. The most widespread use of multitier architecture is the **three-tier/layer architecture**.

N-layer application architecture provides a model by which developers can create flexible and reusable applications. By segregating an application into layers, developers acquire the option of modifying or adding a specific layer, instead of reworking the entire application. A three-layer architecture is typically composed of a **presentation layer**, a **logic (Services) layer**, and a **data layer**.

While the concepts of **layer** and **tier** are often used interchangeably, one fairly common point of view is that there is indeed a difference. This view holds that a **layer is a logical structuring mechanism for the conceptual elements that make up the software solution**, while a **tier is a physical structuring mechanism for the hardware elements that make up the system infrastructure**.

![image](https://user-images.githubusercontent.com/34960418/205287285-4da1e84e-d886-4952-8ea5-ca47b928cab7.png)

![image](https://user-images.githubusercontent.com/34960418/205287629-38c49499-6eba-47bd-bafb-ceae9f218d0a.png)

## Layers

- Presentation layer (a.k.a. UI layer, view layer, presentation tier in multitier architecture)
- Business layer (a.k.a. business logic layer (BLL), domain logic layer)
- Data access layer (a.k.a. persistence layer, logging, networking, and other services which are required to support a particular business layer)

### Presentation Layer

This is the topmost level of the application. The presentation layer displays information related to such services as browsing merchandise, purchasing and shopping cart contents. In simple terms, it is a layer that users can access directly (such as a web page, or an operating system's GUI).

### Service Layer

The service layer is pulled out from the presentation layer and, as its layer, it controls an application’s functionality by performing detailed processing.

### Data Layer

The data access layer encapsulates the persistence mechanisms and exposes the data. The data access layer should provide an API to the service layer that exposes methods of managing the stored data without exposing or creating dependencies on the data storage mechanisms. As with the separation of any layer, there are costs for implementation and often costs to performance in exchange for improved maintainability.


# Examples

[N-Layer Architecture](https://github.com/pirocorp/Simple-nLayer-Architecture)
