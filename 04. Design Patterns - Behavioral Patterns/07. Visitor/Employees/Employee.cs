namespace Visitor.Employees;

using Visitors;

/// <summary>
/// The 'ConcreteElement' class
/// </summary>
/// <remarks>
/// Implements an Accept operation that takes a visitor as an argument
/// </remarks>
public class Employee : IEmployee
{
    public Employee(string name, decimal income, int vacationDays)
    {
        Name = name;
        Income = income;
        VacationDays = vacationDays;
    }

    public string Name { get; }

    public decimal Income { get; set; }

    public int VacationDays { get; set; }

    public void Accept(IVisitor visitor)
        => visitor.Visit(this);
}
