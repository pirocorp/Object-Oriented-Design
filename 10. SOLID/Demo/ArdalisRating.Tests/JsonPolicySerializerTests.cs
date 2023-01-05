namespace ArdalisRating.Tests;

using ArdalisRating.Core.Model;
using Core.Policies;
using Infrastructure.Serializers;
using Xunit;

public class JsonPolicySerializerTests
{
    [Fact]
    public void ReturnsDefaultPolicyDtoFromEmptyJsonString()
    {
        var inputJson = "{}";
        var serializer = new JsonPolicySerializer();

        var result = serializer.GetPolicyInputFromString(inputJson);

        var policy = new PolicyModel();
        AssertPoliciesEqual(result, policy);
    }

    [Fact]
    public void ReturnsSimpleAutoPolicyFromValidJsonString()
    {
        var inputJson = @"{
  ""type"": ""Auto"",
  ""make"": ""BMW""
}
";
        var serializer = new JsonPolicySerializer();

        var result = serializer.GetPolicyInputFromString(inputJson);

        var policy = new PolicyModel() {
            Type = PolicyType.Auto,
            Make = "BMW"
        };

        AssertPoliciesEqual(result, policy);
    }

    private static void AssertPoliciesEqual(PolicyModel result, PolicyModel policy)
    {
        Assert.Equal(result.Type, policy.Type);
        Assert.Equal(result.FullName, policy.FullName);
        Assert.Equal(result.DateOfBirth, policy.DateOfBirth);
        Assert.Equal(result.IsSmoker, policy.IsSmoker);
        Assert.Equal(result.Amount, policy.Amount);
        Assert.Equal(result.Address, policy.Address);
        Assert.Equal(result.Size, policy.Size);
        Assert.Equal(result.Valuation, policy.Valuation);
        Assert.Equal(result.BondAmount, policy.BondAmount);
        Assert.Equal(result.Make, policy.Make);
        Assert.Equal(result.Model, policy.Model);
        Assert.Equal(result.Year, policy.Year);
        Assert.Equal(result.Miles, policy.Miles);
        Assert.Equal(result.Deductible, policy.Deductible);
    }
}
