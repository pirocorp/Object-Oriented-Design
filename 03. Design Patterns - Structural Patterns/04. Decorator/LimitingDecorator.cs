namespace Decorator;

using System;
using System.Collections.Generic;
using System.Linq;

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
        Console.WriteLine($"LIMITING the count to {this.count} elements");

        return this.decoratedReader.Read().Take(this.count);
    }
}