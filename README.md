# 🛠️ Design Patterns


<h3 align="center">
Adaptation of <a href="https://github.com/kamranahmedse/design-patterns-for-humans">Design Patterns for Humans</a>  to C#
</h3>
<p align="center"><sub>All the explanation for design patterns stays the same, with minor changes.</sub></p>

****

<p align="center">
🎉 Ultra-simplified explanation to design patterns! 🎉
</p>
<p align="center">
A topic that can easily make anyone's mind wobble. Here I try to make them stick in to your mind (and maybe mine) by explaining them in the <i>simplest</i> way possible.
</p>
<p align="center">
You can find full length examples for code snippets used in this articles <a href="https://github.com/anupavanm/csharp-design-patterns-for-humans-examples">here.</a>
</p>

****

## 🚀 Introduction

Design patterns are solutions to recurring problems; **guidelines on how to tackle certain problems**. They are not classes, packages or libraries that you can plug into your application and wait for the magic to happen. These are, rather, guidelines on how to tackle certain problems in certain situations.

> Design patterns are solutions to recurring problems; guidelines on how to tackle certain problems

Wikipedia describes them as

> In software engineering, a software design pattern is a general reusable solution to a commonly occurring problem within a given context in software design. It is not a finished design that can be transformed directly into source or machine code. It is a description or template for how to solve a problem that can be used in many different situations.

## ⚠️ Be Careful

- Design patterns are not a silver bullet to all your problems.
- Do not try to force them; bad things are supposed to happen, if done so. Keep in mind that design patterns are solutions **to** problems, not solutions **finding** problems; so don't overthink.
- If used in a correct place in a correct manner, they can prove to be a savior; or else they can result in a horrible mess of a code.

## 🔠 Types of Design Patterns (GoF)

* [Creational](02.%20Design%20Patterns%20-%20Creational%20Patterns)
* [Structural](03.%20Design%20Patterns%20-%20Structural%20Patterns)
* [Behavioral](04.%20Design%20Patterns%20-%20Behavioral%20Patterns)

## 🔃 Other Design Patterns

* [Repository](06.%20Repositories)
* [Specification](07.%20Specification)
* [Dependency Injection](08.%20DI%20Pattern)



# 🏗 Architectural Patterns

* [MVC](10.%20Architectural%20Patterns/MVC.md)
* [MVVM](10.%20Architectural%20Patterns/MVVM.md)
* [MVP](10.%20Architectural%20Patterns/MVP.md)
* [N-Layer Architecture](10.%20Architectural%20Patterns/N-Layer.md)
* [Clean/Hexagonal/Onion Architecture (CHO)](10.%20Architectural%20Patterns/CHO%20Architecture.md)


# 🔘 Domain-Driven Design (DDD)

**Domain-Driven Design is a way to design a subset of the objects in the system.**

In **DDD**, the main goal is to establish **common language** with the **business experts**. The separation of the domain from rest of the application code is just a side effect of this main goal. It also has some say about the design of classes as entities and aggregates, but that is only within the domain itself. It has nothing to say about design outside the domain code.

**Clean**/**Hexagonal**/**Onion** (or CHO in short) architecture, is an architectural pattern for a system, whereas **DDD** is a way to design a subset of the objects in the system. The two can exist without eachother, so neither is a subset of the other. If you were to use them together - then as a whole the part that is designed using DDD would be a subset of the entire system.

# License

[![License: CC BY 4.0](https://img.shields.io/badge/License-CC%20BY%204.0-lightgrey.svg)](https://creativecommons.org/licenses/by/4.0/)

