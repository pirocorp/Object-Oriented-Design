namespace DI_Pattern;

public interface IFormatter
{
    string Format(IEnumerable<Person> people);
}