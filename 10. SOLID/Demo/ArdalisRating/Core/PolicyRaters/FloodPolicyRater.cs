namespace ArdalisRating.Core.PolicyRaters;

using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Policies;

public class FloodPolicyRater : Rater
{
    public FloodPolicyRater(
        ILogger logger,
        FloodPolicy policy)
        : base(logger)
    {
        this.Policy = policy;
    }

    private FloodPolicy Policy { get; }

    public override decimal Rate()
    {
        this.Logger.Log("Rating FLOOD policy...");
        this.Logger.Log("Validating policy...");

        if (this.Policy.BondAmount == 0 || this.Policy.Valuation == 0)
        {
            this.Logger.Log("Flood policy must specify Bond Amount and Valuation.");
            return 0;
        }

        if (this.Policy.ElevationAboveSeaLevelFeet <= 0)
        {
            this.Logger.Log("Flood policy is not available for elevations at or below sea level.");
            return 0;
        }

        if (this.Policy.BondAmount < 0.8m * this.Policy.Valuation)
        {
            this.Logger.Log("Insufficient bon amount.");
            return 0;
        }

        var multiple = this.Policy.ElevationAboveSeaLevelFeet switch
        {
            < 100 => 2.0m,
            < 500 => 1.5m,
            < 1000 => 1.1m,
            _ => 1.0m
        };

        return this.Policy.BondAmount * 0.05m * multiple;
    }
}
