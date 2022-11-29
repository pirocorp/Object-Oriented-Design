namespace Mediator;

using System;

public static class Program
{
    public static void Main()
    {
        var chatRoom = new ChatRoom();

        var eddie = new Actor("Eddie");
        var jennifer = new Actor("Jennifer");
        var bruce = new Actor("Bruce");
        var tom = new Actor("Tom");
        var tony = new NonActor("Tony");

        chatRoom.Register(eddie);
        chatRoom.Register(jennifer);
        chatRoom.Register(bruce);
        chatRoom.Register(tom);
        chatRoom.Register(tony);

        tony.Send("Tom", "Hey Tom! I got mission for you.");
        jennifer.Send("Bruce", "Teach me to act and I'll teach you to dance.");
        bruce.Send("Eddie", "How come you don't do standup anymore?");
        jennifer.Send("Tom", "Do you like math?");
        tom.Send("Tony", "Teach me to sing.");
    }
}
