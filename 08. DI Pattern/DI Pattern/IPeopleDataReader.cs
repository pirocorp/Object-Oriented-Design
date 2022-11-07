namespace DI_Pattern;

public interface IPeopleDataReader
{
    IEnumerable<Person> ReadPeople();
}