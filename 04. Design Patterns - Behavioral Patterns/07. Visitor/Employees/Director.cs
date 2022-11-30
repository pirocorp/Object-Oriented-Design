namespace Visitor.Employees;

/// <summary>
/// The 'ConcreteElement' class
/// </summary>
/// <remarks>
/// Implements an Accept operation that takes a visitor as an argument
/// </remarks>
public class Director : Employee
{
    public Director()
        : base("Elly", 35000.0M, 16)
    {
    }
}
