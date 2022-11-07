namespace DI_Pattern;

using System;

public static class Program
{
    public static void Main()
    {
        //creation of objects
        var logger = new Logger();
        var peopleDataReader = new PeopleDataReader(logger);
        var formatterFactory = new FormatterFactory();

        var personalDataFormatter = new PersonalDataFormatter(
            logger,
            peopleDataReader,
            formatterFactory);

        //actual run of the application
        Console.WriteLine(personalDataFormatter.Format(true));
    }
}