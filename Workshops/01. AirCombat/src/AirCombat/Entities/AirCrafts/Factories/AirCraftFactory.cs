using AirCombat.Entities.Miscellaneous;

namespace AirCombat.Entities.AirCrafts.Factories;

using System;
using System.Linq;
using System.Reflection;

using AirCrafts.Contracts;
using Contracts;

public class AirCraftFactory : IAirCraftFactory
{
    public IAirCraft CreateAirCraft
        (string aircraftType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
    {
        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == aircraftType);

        if (type is null)
        {
            throw new ArgumentException($"Invalid Aircraft of type {aircraftType}");
        }

        var aircraft = (IAirCraft?)Activator.CreateInstance(
            type, 
            model, 
            weight, 
            price, 
            attack, 
            defense, 
            hitPoints, 
            new AircraftAssembler());

        if (aircraft is null)
        {
            throw new InvalidOperationException($"Can't create aircraft of type {aircraftType}");
        }

        return aircraft;
    }
}