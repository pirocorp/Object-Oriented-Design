// Decorator is a design pattern that dynamically adds extra functionality to
// an existing object, without affecting the behavior of other objects from
// the same class
namespace Decorator
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            // Using decorators
            // var loggingCountLimitingReader = new LimitingDecorator(
            //     new LoggingDecorator(new PeopleDataReader(), new Logger()),
            //     3);
               
            // var people = loggingCountLimitingReader.Read();
               
            // foreach (var person in people)
            // {
            //     Console.WriteLine(person);
            // }

            // var loggingReader = new LoggingDecorator(
            //     new PeopleDataReader(), 
            //     new Logger());
               
            // var people1 = loggingReader.Read();
               
            // foreach (var person in people1)
            // {
            //     Console.WriteLine(person);
            // }

            var limitingReader = new LimitingDecorator(new PeopleDataReader(), 3);

            var people2 = limitingReader.Read();

            foreach (var person in people2)
            {
                Console.WriteLine(person);
            }
        }
    }
}
