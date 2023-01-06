namespace AirCombat.Entities.Parts.Factories;

using System;
using System.Linq;
using System.Reflection;

using Contracts;
using Parts.Contracts;

public class PartFactory : IPartFactory
{
    private const string PartNameSuffix = "Part";

    public IPart CreatePart(
        string partType, 
        string model, 
        double weight, 
        decimal price, 
        int additionalParameter)
    {
        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == partType + PartNameSuffix);

        if (type is null)
        {
            throw new InvalidOperationException($"Invalid part of type: {partType}");
        }

        var part = (IPart?)Activator
            .CreateInstance(type, model, weight, price, additionalParameter);

        if (part is null)
        {
            throw new InvalidOperationException($"Can't create part from type: {partType}");
        }

        return part;
    }
}
