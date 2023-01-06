using AirCombat.Entities.AirCrafts.Contracts;

namespace AirCombat.Core.Contracts;

public interface IBattleOperator
{
    string Battle(IAirCraft attacker, IAirCraft target);
}