namespace Visitor.Employees;

using Visitor.Visitors;

/// <summary>
/// The 'Element' abstract class
/// </summary>
/// <remarks>
/// Defines an Accept operation that takes a visitor as an argument.
/// </remarks>
public interface IEmployee
{
    public string Name { get; }

    public decimal Income { get; set; }

    public int VacationDays { get; set; }

    void Accept(IVisitor visitor);
}
