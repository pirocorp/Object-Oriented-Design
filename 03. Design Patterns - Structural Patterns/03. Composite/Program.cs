namespace Composite
{
    using System;
    using System.Collections.Generic;
    using Composite.Employees;

    public static class Program
    {
        public static void Main()
        {
            EmployeesDemo();
        }

        public static void EmployeesDemo()
        {
            var ceo = new Supervisor() { Id = 0, Name = "The Big Boss", Rating = 5 };

            var peter = new Employee() { Id = 1, Name = "Peter", Rating = 3 };
            var george = new Employee() { Id = 2, Name = "George", Rating = 4 };
            var john = new Employee() { Id = 3, Name = "John", Rating = 5 };
            var adam = new Employee() { Id = 4, Name = "Adam", Rating = 3 };
            var martin = new Employee() { Id = 5, Name = "Martin", Rating = 3 };
            var jenny = new Employee() { Id = 6, Name = "Jenny", Rating = 3 };

            var michael = new Supervisor() { Id = 7, Name = "Michael", Rating = 3 };
            var justin = new Supervisor() { Id = 8, Name = "Justin", Rating = 3 };

            ceo.AddSubordinate(michael);
            ceo.AddSubordinate(justin);

            michael.AddSubordinate(peter);
            michael.AddSubordinate(george);
            michael.AddSubordinate(john);

            justin.AddSubordinate(adam);
            justin.AddSubordinate(martin);
            justin.AddSubordinate(jenny);

            ceo.PerformanceSummary();
        }
    }
}