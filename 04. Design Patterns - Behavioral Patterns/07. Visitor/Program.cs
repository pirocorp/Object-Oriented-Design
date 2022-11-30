namespace Visitor;

using Employees;
using Visitors;

public static class Program
{
    public static void Main()
    {
        // Setup employee collection
        var enterprise = new Enterprise();
        enterprise.Attach(new Clerk());
        enterprise.Attach(new Director());
        enterprise.Attach(new President());

        // Visit employees in the collection
        enterprise.Accept(new IncomeVisitor());
        enterprise.Accept(new VacationVisitor());
    }
}
