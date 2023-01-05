namespace ArdalisRating.Core.Interfaces;

using ArdalisRating.Core.Model;

public interface IPolicySerializer
{
    PolicyModel GetPolicyInputFromString(string policyString);
}
