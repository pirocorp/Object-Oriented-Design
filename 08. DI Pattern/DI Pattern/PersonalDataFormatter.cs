namespace DI_Pattern;

public class PersonalDataFormatter
{
    private readonly ILogger logger;
    private readonly IPeopleDataReader peopleDataReader;
    private readonly IFormatterFactory formatterFactory;

    // Constructor injection
    public PersonalDataFormatter(
        ILogger logger, 
        IPeopleDataReader peopleDataReader, 
        IFormatterFactory formatterFactory)
    {
        this.logger = logger;
        this.peopleDataReader = peopleDataReader;
        this.formatterFactory = formatterFactory;
    }

    public string Format(bool isDefault = true)
    {
        this.logger.Log("Formatter running");
        var people = this.peopleDataReader.ReadPeople();

        if (isDefault)
        {
            return string.Join("\n", people.Select(p
                => $"{p.Name} born in {p.Country} on {p.YearOfBirth}"));
        }

        // Create dependency runtime from factory
        var formatter = this.formatterFactory.Create();
        return formatter.Format(people);
    }
}