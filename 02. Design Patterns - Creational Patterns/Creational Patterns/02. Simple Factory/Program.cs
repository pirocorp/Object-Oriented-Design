namespace Simple_Factory;

using System;
using UserName;

public static class Program
{
    public static void Main()
    {
        var factory = new UsernameFactory();

        var name1 = factory.GetUserName("Zdravkov, Zdravko");
        var name2 = factory.GetUserName("Zdravko Zdravkov");

        Console.WriteLine($"{name1.GetType().Name}, {name1.FirstName} {name1.LastName}");
        Console.WriteLine($"{name2.GetType().Name}, {name2.FirstName} {name2.LastName}");
    }
}
