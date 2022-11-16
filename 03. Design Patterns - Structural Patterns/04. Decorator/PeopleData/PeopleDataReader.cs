namespace Decorator.PeopleData;

using System.Collections.Generic;

public class PeopleDataReader : IPeopleDataReader
{
    public IEnumerable<Person> Read()
    {
        return new List<Person>
        {
            new ("Martin", 1972, "France"),
            new ("Aiko", 1995, "Japan"),
            new ("Selene", 1944, "Great Britain"),
            new ("Michael", 1980, "Canada"),
            new ("Anne", 1972, "New Zealand"),
        };
    }
}