namespace Visitor.Employees;

/// <summary>
/// The 'ConcreteElement' class
/// </summary>
/// <remarks>
/// Implements an Accept operation that takes a visitor as an argument
/// </remarks>
public class Clerk : Employee
{
    public Clerk()
        : base("Kevin", 25000.0M, 14)
    { }
}
