namespace Decorator;

using System.Collections.Generic;

public interface IPeopleDataReader
{
    IEnumerable<Person> Read();
}