namespace ArdalisRating.Infrastructure.PolicySources;

using System.IO;

using ArdalisRating.Core.Interfaces;

public class FilePolicySource : IPolicySource
{
    public string GetPolicyFromSource()
        => File.ReadAllText("policy.json");
}
