namespace Visitor.Employees;

/// <summary>
/// The 'ConcreteElement' class
/// </summary>
/// <remarks>
/// Implements an Accept operation that takes a visitor as an argument
/// </remarks>
public class President : Employee
{
    public President()
        : base("Eric", 45000.0M, 21)
    { }
}
