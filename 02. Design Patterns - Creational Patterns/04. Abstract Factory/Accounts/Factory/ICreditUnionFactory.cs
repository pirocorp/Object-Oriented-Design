namespace Abstract_Factory.Accounts.Factory;

/// <summary>
/// Abstract factory
/// </summary>
public interface ICreditUnionFactory
{
    ISavingsAccount CreateSavingsAccount();

    ILoanAccount CreateLoanAccount();
}