# MVC

![image](https://user-images.githubusercontent.com/34960418/204827508-856f28ee-98d2-461b-91f1-b32f8a24cb07.png)

**Model–view–controller** (**MVC**) is a software architectural pattern commonly used for developing user interfaces that divide the related program logic into three interconnected elements. This is done to separate internal representations of information from the ways information is presented to and accepted from the user.


# Components

## Model

The central component of the pattern. It is the application's dynamic data structure, independent of the user interface. It directly manages the data, logic and rules of the application. **The design of a model type is left entirely to the programmer**.


## View

A view is just a visual representation of a model, and does not handle user input. Views are meant to be general-purpose and composable. In ASP.NET Core the role of the view is played by HTML templates, so in their scheme a view specifies an in-browser user interface rather than representing a user interface widget directly.


## Controller

Accepts input and converts it to commands for the model or view. At any given time, each controller has one associated view and model, although one model object may hear from many different controllers. Only one controller, the "active" controller, receives user input at any given time; a global manager object is responsible for setting the current active controller. If user input prompts a change in a model, the controller will signal the model to change, but the model is then responsible for telling its views to update.


# Interactions

In addition to dividing the application into these components, the model–view–controller design defines the interactions between them.

- The model is responsible for managing the data of the application. It receives user input from the controller.
- The view renders presentation of the model in a particular format.
- The controller responds to the user input and performs interactions on the data model objects. The controller receives the input, optionally validates it and then passes the input to the model.

As with other software patterns, MVC expresses the "core of the solution" to a problem while allowing it to be adapted for each system. 

# Use in web applications

Although originally developed for desktop computing, MVC has been widely adopted as a design for World Wide Web applications in major programming languages. These software frameworks vary in their interpretations, mainly in the way that the MVC responsibilities are divided between the client and server.

Some web MVC frameworks take a thin client approach that places almost the entire model, view and controller logic on the server. In this approach, the client sends either hyperlink requests or form submissions to the controller and then receives a complete and updated web page (or other document) from the view; the model exists entirely on the server.

