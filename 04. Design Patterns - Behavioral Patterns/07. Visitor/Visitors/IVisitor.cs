namespace Visitor.Visitors;

using Employees;

/// <summary>
/// The abstract 'Visitor'
/// </summary>
/// <remarks>
/// Declares a Visit operation for each class of Concrete Employee
/// in the object structure. The operation's name and signature
/// identifies the class that sends the Visit request to the visitor.
/// That lets the visitor determine the concrete class of the employee
/// being visited. Then the visitor can access the elements directly
/// through its particular interface
/// </remarks>
public interface IVisitor
{
    void Visit(IEmployee employee);
}
