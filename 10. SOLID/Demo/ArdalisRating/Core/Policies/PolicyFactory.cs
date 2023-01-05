namespace ArdalisRating.Core.Policies;

using System;
using System.Linq;
using System.Reflection;

using ArdalisRating.Core.Model;
using ArdalisRating.Infrastructure.Extensions;

public class PolicyFactory
{
    public Policy Create(PolicyModel dto)
    {
        try
        {
            return (Policy)this.CreatePolicy(dto);
        }
        catch
        {
            return new UnknownPolicy();
        }
    }

    private object CreatePolicy(PolicyModel dto)
    {
        var properties = dto
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Select(p => new
            {
                Name = p.Name.ToCamelCase(),
                Value = p.GetValue(dto)
            })
            .ToDictionary(
                x => x.Name,
                x => x.Value);

        var policyType = $"ArdalisRating.Core.Policies.{dto.Type}Policy";

        var policyConstructor = Type
            .GetType(policyType)
            ?.GetConstructors()
            .First();

        var constructorParameters = policyConstructor
            ?.GetParameters()
            .Select(x => properties[x.Name?.ToCamelCase()])
            .ToArray();

        var result = policyConstructor?.Invoke(constructorParameters);

        return result ?? new UnknownPolicy();
    }
}
