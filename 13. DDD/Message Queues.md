# Message Queues

## Introducing Message Queues

**Message Queues** decuples applications and make it so that one of the applications can drop off something into a **Message Queue** and continue with its work and not have to worry about what happens to the message after that. 

Applications trying to communicate with one another don't need to worry that the other application is available and listening at that very moment. The message can sit in a queue, and when the other application is ready, it does grab it. 

With the **Message Queue**, we were dealing with a single message. One application drops it, another takes it, and then the message is gone.

![image](https://user-images.githubusercontent.com/34960418/214043868-275b1f53-6291-47e9-bbf8-6e99046b0282.png)

Sometimes a number of applications are interested in that message, and you might not even know in advance or control those applications. So this is when something called **Service Bus** comes into play. 

![image](https://user-images.githubusercontent.com/34960418/214044803-68de5b74-0954-4051-8e43-3c4185369862.png)

**Service Bus** usually sits on top of **Message Queues*, and one of its responsibilities is ensuring that messages get delivered to different applications that care about that messages.

## Sending a Message to the Queue
