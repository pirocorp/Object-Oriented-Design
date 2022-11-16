namespace Facade.Loans
{
    using System;

    internal class Bank
    {
        public bool HasSufficientSavings(Borrower borrower, decimal amount)
        {
            Console.WriteLine($"Verify bank for {borrower.Name}");

            return true;
        }
    }
}
