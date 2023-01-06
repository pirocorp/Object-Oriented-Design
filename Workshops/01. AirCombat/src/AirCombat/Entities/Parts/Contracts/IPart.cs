using AirCombat.Entities.CommonContracts;

namespace AirCombat.Entities.Parts.Contracts;

public interface IPart : IModelable
{
    double Weight { get; }

    decimal Price { get; }
}