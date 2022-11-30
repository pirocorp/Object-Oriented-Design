namespace Visitor;

using System;
using System.Collections.Generic;

using Visitor.Employees;
using Visitors;

/// <summary>
/// The 'ObjectStructure' class
/// </summary>
/// <remarks>
/// Can enumerate its elements. May provide a high-level
/// interface to allow the visitor to visit its elements.
/// May either be a Composite (pattern) or a collection
/// such as a list or a set.
/// </remarks>
public class Enterprise
{
    private readonly List<IEmployee> employees;

    public Enterprise()
    {
        this.employees = new List<IEmployee>();
    }

    public void Attach(IEmployee employee)
    {
        employees.Add(employee);
    }

    public void Detach(IEmployee employee)
    {
        employees.Remove(employee);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var employee in employees)
        {
            employee.Accept(visitor);
        }

        Console.WriteLine();
    }
}
