namespace Facade
{
    using System;

    using Loans;

    public static class Program
    {
        public static void Main()
        {
            var loanProvider = new LoanProvider();

            var borrower = new Borrower("Zdravko Zdravkov");
            var eligible = loanProvider.IsEligible(borrower, 1_000_000);

            Console.WriteLine();
            Console.WriteLine($"{borrower.Name} has been {(eligible ? "Approved" : "Rejected" )}");
        }
    }
}