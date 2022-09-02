namespace Abstract_Factory.Accounts.Factory;

using Chase;

public class ChaseCreditUnionFactory : ICreditUnionFactory
{
    public ISavingsAccount CreateSavingsAccount() => new ChaseSavingsAccount();

    public ILoanAccount CreateLoanAccount() => new ChaseLoanAccount();
}