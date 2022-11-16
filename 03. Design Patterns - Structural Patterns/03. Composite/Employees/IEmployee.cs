namespace Composite.Employees
{
    /// <summary>
    /// Component
    /// </summary>
    public interface IEmployee
    {
        int Id { get; }

        string Name { get; }

        int Rating { get; }

        void PerformanceSummary();
    }
}
