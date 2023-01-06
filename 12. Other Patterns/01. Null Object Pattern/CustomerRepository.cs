namespace NullObjectPattern;

using System.Collections.Generic;
using System.Linq;

public class CustomerRepository
{
    private readonly Dictionary<string, Customer> customers;

    public CustomerRepository()
    {
        this.customers = new Dictionary<string, Customer>();

        this.InitializeCustomers();
    }

    public IEnumerable<Customer> List => this.customers.Values.ToList();

    public Customer GetByPhoneNumber(string phoneNumber)
        => this.customers
            .TryGetValue(phoneNumber, out var value) 
            ? value 
            : Customer.NotFound;

    private void InitializeCustomers()
        => new List<Customer>()
        {
            new ()
            {
                Name = "Zdravko Zdravkov",
                OrderCount = 5,
                TotalSales = 25_000,
                Phone = "+359 123456"
            },
            new ()
            {
                Name = "Piroman Piromanov",
                OrderCount = 2,
                TotalSales = 5_000,
                Phone = "+359 555123"
            },
            new ()
            {
                Name = "Asen Zlatarov",
                OrderCount = 5,
                TotalSales = 1_000,
                Phone = "+359 123555"
            },
        }
        .ForEach(c => this.customers.Add(c.Phone, c));
}
