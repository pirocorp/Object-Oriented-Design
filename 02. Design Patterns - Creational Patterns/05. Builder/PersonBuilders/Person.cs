namespace Builder.PersonBuilders;

using System;
using System.Text;

public class Person
{
    public string Id { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public string Occupation { get; set; } = string.Empty;

    public Gender Gender { get; set; }

    public override string ToString()
        => new StringBuilder()
            .Append("Person with id: ")
            .Append(Id)
            .Append(" with date of birth ")
            .Append(this.DateOfBirth.ToLongDateString())
            .Append(" and name ")
            .Append(FirstName)
            .Append(" ")
            .Append(LastName)
            .Append(" is a ")
            .Append(this.Occupation)
            .ToString();
}
