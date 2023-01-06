namespace NullObjectPattern;

using System;

public static class Program
{
    private static readonly CustomerRepository CustomerRepository;

    static Program()
    {
        CustomerRepository = new CustomerRepository();
    }

    public static void Main()
    {
        var customer = CustomerRepository.GetByPhoneNumber("+359 123456");

        Console.WriteLine(customer.Name);
        Console.WriteLine(customer.OrderCount);
        Console.WriteLine(customer.TotalSales);

        Console.WriteLine(new string('-', 50));

        var notFoundCustomer = CustomerRepository.GetByPhoneNumber("Invalid");

        Console.WriteLine(notFoundCustomer.Name);
        Console.WriteLine(notFoundCustomer.OrderCount);
        Console.WriteLine(notFoundCustomer.TotalSales);
    }
}
