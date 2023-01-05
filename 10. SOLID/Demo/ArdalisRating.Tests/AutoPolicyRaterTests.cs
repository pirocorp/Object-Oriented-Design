namespace ArdalisRating.Tests;

using System.Linq;

using ArdalisRating.Core.Policies;
using ArdalisRating.Core.PolicyRaters;

using Xunit;

public class AutoPolicyRaterTests
{
    [Fact]
    public void LogsMakeRequiredMessageGivenPolicyWithoutMake()
    {
        var policy = new AutoPolicy(
            string.Empty, 
            string.Empty, 
            0, 
            0, 
            0);

        var logger = new FakeLogger();
        var rater = new AutoPolicyRater(logger, policy);
        rater.Rate();

        Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
    }

    [Fact]
    public void SetsRatingTo1000ForBmwWith250Deductible()
    {
        var policy = new AutoPolicy(
            "BMW",
            "420",
            2022,
            2000,
            250m);

        var rater = new AutoPolicyRater(new FakeLogger(), policy);

        var actual = rater.Rate();
        Assert.Equal(1000m, actual);
    }

    [Fact]
    public void SetsRatingTo900ForBmwWith500Deductible()
    {
        var policy = new AutoPolicy(
            "BMW",
            "420",
            2022,
            2000,
            500m);

        var rater = new AutoPolicyRater(new FakeLogger(), policy);
        var actual = rater.Rate();

        Assert.Equal(900m, actual);
    }
}
