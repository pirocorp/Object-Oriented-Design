namespace ValueObjectDemo;

using System.Collections.Generic;

public class AddressValueObjectAsClass : ValueObject
{
    public AddressValueObjectAsClass(
        string street, 
        string city, 
        string state, 
        string country, 
        string zipCode)
    {
        this.Street = street;
        this.City = city;
        this.State = state;
        this.Country = country;
        this.ZipCode = zipCode;
    }

    public string Street { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public string Country { get; private set; }

    public string ZipCode { get; private set; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return this.Street;
        yield return this.City;
        yield return this.State;
        yield return this.Country;
        yield return this.ZipCode;
    }
}
