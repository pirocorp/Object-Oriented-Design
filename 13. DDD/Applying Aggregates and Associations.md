# Applying Aggregates and Associations

## Tackling Data Complexity

Large systems often lead to complex data models. One way to reduce the data complexity is to use **Aggregates** and **Aggregate Roots**. Another is limiting how many bi-directional relationships you have in a data model. If your design does not have any clear notion of **Aggregates**, the dependencies between your entities may grow out of control resulting in a model like this one.

![image](https://user-images.githubusercontent.com/34960418/212371380-89bd415b-7212-46fb-841f-9772d5bf21e6.png)

And if your object model reflects the data model like this one trying to populate all of the dependent objects of one object may result in trying to load the entire database in memory. And the same problem exists when it is time to save changes. With a model like this, there is no limit to which areas of the data model might be affected.

![image](https://user-images.githubusercontent.com/34960418/212372473-6cf34a88-1766-4788-ad6f-a418e84bbd28.png)


## Introducing Aggregates and Aggregate Roots

**Aggregates** consist of one or more **Entities** and **ValueObjects** that change together. We need to treat them as a unit for data changes and consider the entire **Aggregates** consistency before we apply changes.

An example may be an order and its items. These will be separate objects, but treating the order (together with its items) as a single **Aggregate** is helpful. 

Every **Aggregate** must have an **Aggregate Root** which is the parent object of all members of the **Aggregate**. It's possible to have an **Aggregate** that consists of just one object, in which case that object will still be the **Aggregate Root**. Any references from outside the aggregate should only go to the **Aggregate Root**. The **Aggregate Root** can thus ensure the integrity of the **Aggregate** as a whole.

**Aggregates** are the basic element of transfer of data storage - you request to load or save whole **Aggregates**. Transactions should not cross **Aggregate** boundaries.

**Aggregates** are sometimes confused with collection classes (lists, maps, etc). **Aggregates** are domain concepts (order, clinic visit, playlist), while collections are generic. An **Aggregate** will often contain mutliple collections, together with simple fields. The term **Aggregate** is a common one, and is used in various different contexts (e.g. UML), in which case it does not refer to the same concept as a DDD **Aggregate**.

