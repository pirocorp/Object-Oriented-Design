namespace ArdalisRating.Core.PolicyRaters;

using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Policies;

public class LandPolicyRater : Rater
{
    public LandPolicyRater(
        ILogger logger,
        LandPolicy policy)
        : base(logger)
    {
        this.Policy = policy;
    }

    private LandPolicy Policy { get; }

    public override decimal Rate()
    {
        this.Logger.Log("Rating LAND policy...");
        this.Logger.Log("Validating policy.");

        if (this.Policy.BondAmount == 0 || this.Policy.Valuation == 0)
        {
            this.Logger.Log("Land policy must specify Bond Amount and Valuation.");
            return 0;
        }

        if (this.Policy.BondAmount < 0.8m * this.Policy.Valuation)
        {
            this.Logger.Log("Insufficient bond amount.");
            return 0;
        }

        return this.Policy.BondAmount * 0.05m;
    }
}
