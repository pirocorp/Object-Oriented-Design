namespace Abstract_Factory.Accounts;

using Abstract_Factory.Accounts.Factory;

public class CreditUnionFactoryProvider
{
    public static ICreditUnionFactory? GetCreditUnionFactory(string account)
    {
        if (account.Contains("CITI"))
        {
            return new CitiCreditUnionFactory();
        }

        if (account.Contains("National"))
        {
            return new NationalCreditUnionFactory();
        }

        if (account.Contains("CHASE"))
        {
            return new ChaseCreditUnionFactory();
        }

        return null;
    }
}

