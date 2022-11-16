namespace Facade.Loans
{
    using System;

    internal class Credit
    {
        public bool HasGoodCreditScore(Borrower borrower)
        {
            Console.WriteLine($"Verify credit score for {borrower.Name}");

            return true;
        }
    }
}
