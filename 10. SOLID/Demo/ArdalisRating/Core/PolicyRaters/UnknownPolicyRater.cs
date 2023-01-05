namespace ArdalisRating.Core.PolicyRaters;

using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Policies;
using Core;

public class UnknownPolicyRater : Rater
{
    public UnknownPolicyRater(
        ILogger logger,
        UnknownPolicy policy) 
        : base(logger)
    {
        this.Policy = policy;
    }

    private UnknownPolicy Policy { get; }

    public override decimal Rate()
    {
        this.Logger.Log("Unknown policy type.");
        return 0;
    }
}
