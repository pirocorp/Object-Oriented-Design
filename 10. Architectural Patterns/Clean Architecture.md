In **Clean**/**Hexagonal**/**Onion** (or **CHO** in short) architecture, the goal of this decoupling is testability and modularity with intended effect being that the "core" of our software can be reasoned about in isolation from rest of the world.

You use **CHO** architecture to design the whole structure of the system, with the "**domain core**" being isolated in it's separate modules. And then you use **DDD** to design this domain core in collaboration with domain experts and possibly by using **DDD** concepts like **Entites** and **Aggregates**.

**CHO** is an architectural pattern for a system, whereas DDD is a way to design a subset of the objects in the system. The two can exist without eachother, so neither is a subset of the other. If you were to use them together - then as a whole the part that is designed using DDD would be a subset of the entire system.
