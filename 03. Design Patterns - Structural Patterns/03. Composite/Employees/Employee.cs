namespace Composite.Employees
{
    using System;

    /// <summary>
    /// Leaf
    /// </summary>
    public class Employee : IEmployee
    {
        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public int Rating { get; init; }

        public virtual void PerformanceSummary()
        {
            Console.WriteLine();
            Console.WriteLine($"Performance summary of employee: {Name} is {Rating} out of 5");
        }

        public override int GetHashCode() => Id;

        public override bool Equals(object? obj)
        {
            if (obj is Employee employee)
            {
                return employee.Id == Id;
            }

            return false;
        }

        public static bool operator ==(Employee a, Employee b)
            => a.Id == b.Id;

        public static bool operator !=(Employee a, Employee b)
            => a.Id != b.Id;
    }
}
