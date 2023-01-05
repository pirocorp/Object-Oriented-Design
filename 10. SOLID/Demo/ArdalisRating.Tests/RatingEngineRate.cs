namespace ArdalisRating.Tests;

using System.IO;
using ArdalisRating.Core;
using ArdalisRating.Core.Policies;
using Core.PolicyRaters;
using Infrastructure.Serializers;
using Newtonsoft.Json;
using Xunit;

public class RatingEngineRate
{
    private readonly RatingEngine engine;
    private readonly FakeLogger logger;
    private readonly FakePolicySource policySource;
    private readonly JsonPolicySerializer policySerializer;

    public RatingEngineRate()
    {
        this.logger = new FakeLogger();
        this.policySource = new FakePolicySource();
        this.policySerializer = new JsonPolicySerializer();

        this.engine = new RatingEngine(
            this.logger,
            this.policySource,
            this.policySerializer,
            new RaterFactory(this.logger));
    }

    [Fact]
    public void ReturnsRatingOf10000For200000LandPolicy()
    {
        var policy = new LandPolicy(
            string.Empty,
            10,
            200_000,
            200_000);

        var json = JsonConvert.SerializeObject(policy);
        this.policySource.PolicyString = json;

        this.engine.Rate();
        var result = this.engine.Rating;

        Assert.Equal(10000, result);
    }

    [Fact]
    public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
    {
        var policy = new LandPolicy(
            string.Empty,
            10,
            260_000,
            200_000);

        var json = JsonConvert.SerializeObject(policy);
        this.policySource.PolicyString = json;

        this.engine.Rate();
        var result = this.engine.Rating;

        Assert.Equal(0, result);
    }

    [Fact]
    public void LogsStartingLoadingAndCompleting()
    {
        var policy = new LandPolicy(
            string.Empty,
            10,
            260_000,
            200_000);

        var json = JsonConvert.SerializeObject(policy);
        this.policySource.PolicyString = json;

        this.engine.Rate();
        var result = this.engine.Rating;

        Assert.Contains(this.logger.LoggedMessages, m => m == "Starting rate.");
        Assert.Contains(this.logger.LoggedMessages, m => m == "Loading policy.");
        Assert.Contains(this.logger.LoggedMessages, m => m == "Rating completed.");
    }
}
