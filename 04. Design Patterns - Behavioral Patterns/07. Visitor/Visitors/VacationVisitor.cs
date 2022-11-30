namespace Visitor.Visitors;

using System;
using Employees;

/// <summary>
/// A 'ConcreteVisitor' class
/// </summary>
/// <remarks>
/// Implements each operation declared by Visitor.
/// Each operation implements a fragment of the algorithm
/// defined for the corresponding class or object in the structure.
/// ConcreteVisitor provides the context for the algorithm and
/// stores its local state. This state often accumulates results
/// during the traversal of the structure.
/// </remarks>
public class VacationVisitor : IVisitor
{
    public void Visit(IEmployee employee)
    {
        employee.VacationDays += 3;

        Console.WriteLine("{0} {1}'s new vacation days: {2}",
            employee.GetType().Name, 
            employee.Name,
            employee.VacationDays);
    }
}
