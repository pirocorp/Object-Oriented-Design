namespace DI_Pattern
{
    public class NameOnlyFormatter : IFormatter
    {
        public string Format(IEnumerable<Person> people)
        {
            return string.Join("\n",
                people.Select(p => p.Name));
        }
    }
}
