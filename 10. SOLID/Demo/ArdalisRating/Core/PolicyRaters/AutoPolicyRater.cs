namespace ArdalisRating.Core.PolicyRaters;

using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Policies;

public class AutoPolicyRater : Rater
{
    public AutoPolicyRater(
        ILogger logger,
        AutoPolicy policy)
        : base(logger)
    {
        this.Policy = policy;
    }

    private AutoPolicy Policy { get; }

    public override decimal Rate()
    {
        this.Logger.Log("Rating AUTO policy...");
        this.Logger.Log("Validating policy.");

        if (string.IsNullOrEmpty(this.Policy.Make))
        {
            this.Logger.Log("Auto policy must specify Make");
            return 0;
        }

        if (this.Policy.Make == "BMW")
        {
            if (this.Policy.Deductible < 500)
            {
                return 1000m;
            }

            return 900m;
        }

        return 0;
    }
}
