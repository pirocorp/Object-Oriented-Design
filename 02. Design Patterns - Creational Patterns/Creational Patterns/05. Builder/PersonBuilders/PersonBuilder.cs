namespace Builder.PersonBuilders;

using System;

public class PersonBuilder
{
    private Person? person;

    public PersonBuilder Create(string firstName, string lastName)
    {
        this.person = new Person
        {
            FirstName = firstName,
            LastName = lastName,
            Id = Guid.NewGuid().ToString()
        };

        return this;
    }

    public PersonBuilder Gender(Gender gender)
    {
        this.ValidateCreateMethodIsCalled();

        this.person!.Gender = gender;

        return this;
    }

    public PersonBuilder DateOfBirth(DateOnly dateOfBirth)
    {
        this.ValidateCreateMethodIsCalled();

        this.person!.DateOfBirth = dateOfBirth;

        return this;
    }

    public PersonBuilder Occupation(string occupation)
    {
        this.ValidateCreateMethodIsCalled();

        this.person!.Occupation = occupation;

        return this;
    }

    public Person Build()
    {
        this.ValidateCreateMethodIsCalled();

        return this.person!;
    }

    private void ValidateCreateMethodIsCalled()
    {
        if (this.person is not null)
        {
            return;
        }

        const string errorMessage = "PersonBuilder Create method should be called first";
        throw new InvalidOperationException(errorMessage);
    }
}