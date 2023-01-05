using ArdalisRating.Core.Model;

namespace ArdalisRating.Core.Policies;

public class FloodPolicy : Policy
{
    public FloodPolicy(
        decimal valuation,
        decimal bondAmount,
        int elevationAboveSeaLevelFeet)
        : base(PolicyType.Flood)
    {
        this.Valuation = valuation;
        this.BondAmount = bondAmount;
        this.ElevationAboveSeaLevelFeet = elevationAboveSeaLevelFeet;
    }

    public decimal Valuation { get; }

    public decimal BondAmount { get; }

    public int ElevationAboveSeaLevelFeet { get; }
}
