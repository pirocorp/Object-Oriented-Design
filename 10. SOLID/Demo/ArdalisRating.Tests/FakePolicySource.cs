namespace ArdalisRating.Tests;

using Core.Interfaces;

public class FakePolicySource : IPolicySource
{
    public string PolicyString { get; set; } = "";

    public string GetPolicyFromSource()
    {
        return PolicyString;
    }
}
