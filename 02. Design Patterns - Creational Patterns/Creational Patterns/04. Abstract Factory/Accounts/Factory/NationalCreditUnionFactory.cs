namespace Abstract_Factory.Accounts.Factory;

using National;

public class NationalCreditUnionFactory : ICreditUnionFactory
{
    public ISavingsAccount CreateSavingsAccount() => new NationalSavingsAccount();

    public ILoanAccount CreateLoanAccount() => new NationalLoanAccount();
}