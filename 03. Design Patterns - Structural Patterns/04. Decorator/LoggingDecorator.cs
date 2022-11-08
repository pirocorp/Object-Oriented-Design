namespace Decorator;

using System.Collections.Generic;
using System.Linq;

public class LoggingDecorator : IPeopleDataReader
{
    private readonly IPeopleDataReader decoratedReader;
    private readonly ILogger logger;

    public LoggingDecorator(
        IPeopleDataReader decoratedReader,
        ILogger logger)
    {
        this.decoratedReader = decoratedReader;
        this.logger = logger;
    }

    public IEnumerable<Person> Read()
    {
        var data = decoratedReader.Read().ToList();
        logger.Log($"[LOG] Read { data.Count } elements");

        return data;
    }
}