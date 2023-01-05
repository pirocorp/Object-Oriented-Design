namespace ArdalisRating.Core;

using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.PolicyRaters;

public class RatingEngine
{
    private readonly ILogger logger;
    private readonly IPolicySource policySource;
    private readonly IPolicySerializer policySerializer;
    private readonly RaterFactory raterFactory;

    public RatingEngine(ILogger logger, IPolicySource policySource, IPolicySerializer policySerializer, RaterFactory raterFactory)
    {
        this.logger = logger;
        this.policySource = policySource;
        this.policySerializer = policySerializer;
        this.raterFactory = raterFactory;
    }

    public decimal Rating { get; private set; }

    public void Rate()
    {
        this.logger.Log("Starting rate.");
        this.logger.Log("Loading policy.");

        var policyJson = this.policySource.GetPolicyFromSource();
        var dto = this.policySerializer.GetPolicyInputFromString(policyJson);

        var rater = this.raterFactory.Create(dto);
        this.Rating = rater.Rate();

        this.logger.Log("Rating completed.");
    }
}
