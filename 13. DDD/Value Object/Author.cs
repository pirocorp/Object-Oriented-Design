namespace ValueObjectDemo;

using System;

public class Author
{
    public Author(string givenName, string surName)
    {
        this.Id = Guid.NewGuid();
        this.Name = PersonFullNameValueObjectAsClass.Create(givenName, surName);
    }

    public Guid Id { get; init; }

    public PersonFullNameValueObjectAsClass Name { get; private set; }

    public void FixAuthorName(string givenName, string surName)
        => this.Name = PersonFullNameValueObjectAsClass.Create(givenName, surName);
}
