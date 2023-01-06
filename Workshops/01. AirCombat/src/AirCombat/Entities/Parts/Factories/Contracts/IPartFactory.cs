using AirCombat.Entities.Parts.Contracts;

namespace AirCombat.Entities.Parts.Factories.Contracts;

public interface IPartFactory
{
    IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter);
}