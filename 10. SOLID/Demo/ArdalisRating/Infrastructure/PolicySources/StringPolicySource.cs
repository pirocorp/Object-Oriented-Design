namespace ArdalisRating.Infrastructure.PolicySources;

using ArdalisRating.Core.Interfaces;

public class StringPolicySource : IPolicySource
{
    public string PolicyString { get; set; } = "";

    public string GetPolicyFromSource()
    {
        return this.PolicyString;
    }
}
