namespace Decorator.PeopleData.Decorators;

using System;
using System.Collections.Generic;
using System.Linq;
using Decorator.PeopleData;

public class LimitingDecorator : IPeopleDataReader
{
    private readonly IPeopleDataReader decoratedReader;
    private readonly int count;

    public LimitingDecorator(IPeopleDataReader decoratedReader, int count)
    {
        this.decoratedReader = decoratedReader;
        this.count = count;
    }

    public IEnumerable<Person> Read()
    {
        Console.WriteLine($"LIMITING the count to {count} elements");

        return decoratedReader.Read().Take(count);
    }
}