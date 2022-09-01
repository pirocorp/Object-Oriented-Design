namespace Abstract_Factory.Accounts.Factory;

using Citi;

public class CitiCreditUnionFactory : ICreditUnionFactory
{
    public ISavingsAccount CreateSavingsAccount() => new CitiSavingsAccount();

    public ILoanAccount CreateLoanAccount() => new CitiLoanAccount();
}