namespace ValueObjectDemo;

using System;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        var one = new AddressValueObjectAsClass(
            "Valkendal 8",
            "Strombeek-Bever", 
            string.Empty, 
            "Belgium", 
            "1853");

        var two = new AddressValueObjectAsClass(
            "Valkendal 8",
            "Strombeek-Bever", 
            string.Empty, 
            "Belgium", 
            "1853");

        CompareValueObjects(one, two);

        Console.WriteLine(new string('-', 50));

        var name1 = PersonFullNameValueObjectAsClass
            .Create("Zdravko", "Zdravkov");

        var name2 = PersonFullNameValueObjectAsClass
            .Create("Zdravko", "Zdravkov");

        CompareValueObjects(name1, name2);

        var record1 = new PersonFullNameAsRecordValueObject(
            "Zdravko", "Zdravkov");

        var record2 = new PersonFullNameAsRecordValueObject(
            "Zdravko", "Zdravkov");

        Console.WriteLine(new string('-', 50));
        CompareValueObjects(record1, record2);
    }

    private static void CompareValueObjects<T>(T one, T two)
        where T : IValueObject<T>
    {
        Console.WriteLine(EqualityComparer<T>.Default.Equals(one, two)); // True
        Console.WriteLine(object.Equals(one, two)); // True
        Console.WriteLine(one.Equals(two)); // True
        Console.WriteLine(one == two); // True
        Console.WriteLine(one != two); // False
    }
}
