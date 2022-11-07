namespace DI_Pattern
{
    public class FormatterFactory : IFormatterFactory
    {
        public IFormatter Create()
        {
            return new NameOnlyFormatter();
        }
    }
}
