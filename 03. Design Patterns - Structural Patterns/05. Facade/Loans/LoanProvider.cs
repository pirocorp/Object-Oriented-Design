namespace Facade.Loans
{
    using System;

    public class LoanProvider
    {
        private readonly Bank bank;

        private readonly Credit credit;

        private readonly Loan loan;

        public LoanProvider()
        {
            this.bank = new Bank();
            this.credit = new Credit();
            this.loan = new Loan();
        }

        public bool IsEligible(Borrower borrower, decimal amount)
        {
            Console.WriteLine($"{borrower.Name} applies for € {amount:F2} loan.");

            return 
                this.loan.HasNoBadLoans(borrower) 
                && this.credit.HasGoodCreditScore(borrower)
                && this.bank.HasSufficientSavings(borrower, amount);
        }
    }
}
