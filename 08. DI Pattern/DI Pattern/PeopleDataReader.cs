namespace DI_Pattern;

public class PeopleDataReader : IPeopleDataReader
{
    private readonly ILogger logger;

    public PeopleDataReader(ILogger logger)
    {
        this.logger = logger;
    }

    public IEnumerable<Person> ReadPeople()
    {
        this.logger.Log("Reading from database");

        return new List<Person>
        {
            new ("John", 1982, "USA"),
            new ("Aja", 1992, "India"),
            new ("Tom", 1954, "Australia"),
        };
    }
}