namespace ArdalisRating.Infrastructure.Serializers;

using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Model;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class JsonPolicySerializer : IPolicySerializer
{
    public PolicyModel GetPolicyInputFromString(string policyJson)
    {
        var defaultPolicy = new PolicyModel()
        {
            Type = PolicyType.Unknown
        };

        try
        {
            return JsonConvert.DeserializeObject<PolicyModel>(
                        policyJson,
                        new StringEnumConverter())
                ?? defaultPolicy;
        }
        catch
        {
            return defaultPolicy;
        }
    }
}
