namespace ValueObjectDemo;

using System.Collections.Generic;

public class PersonFullNameValueObjectAsClass : ValueObject
{
    private PersonFullNameValueObjectAsClass(
        string givenName, 
        string surName)
    {
        this.GivenName = givenName;
        this.SurName = surName;
    }

    public static PersonFullNameValueObjectAsClass Create(string given, string surname)
        => new (given, surname);

    public string GivenName { get; init; }

    public string SurName { get; init; }

    public string FullName => this.GivenName + " " + this.SurName;

    public string Reverse => this.SurName + " " + this.GivenName;

    public PersonFullNameValueObjectAsClass FamilyMemberWithSameSurname(string newGivenName)
        => Create(newGivenName, this.SurName);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return this.GivenName;
        yield return this.SurName;
    }
}
