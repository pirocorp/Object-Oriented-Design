namespace Composite.Employees
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Composite
    /// </summary>
    public class Supervisor : Employee
    {
        private readonly HashSet<IEmployee> subordinates;

        public Supervisor()
        {
            subordinates = new HashSet<IEmployee>();
        }

        public override void PerformanceSummary()
        {
            base.PerformanceSummary();

            foreach (var subordinate in this.subordinates)
            {
                subordinate.PerformanceSummary();
            }
        }

        public void AddSubordinate(IEmployee employee)
            => subordinates.Add(employee);
    }
}
