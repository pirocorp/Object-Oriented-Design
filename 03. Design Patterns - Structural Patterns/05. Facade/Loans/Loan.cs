namespace Facade.Loans
{
    using System;

    internal class Loan
    {
        public bool HasNoBadLoans(Borrower borrower)
        {
            Console.WriteLine($"Verify loans for {borrower.Name}");

            return true;
        }
    }
}
