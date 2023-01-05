namespace ArdalisRating.Core.PolicyRaters;

using System;

using ArdalisRating.Core.Model;
using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Policies;

public class RaterFactory
{
    private readonly ILogger logger;

    public RaterFactory(ILogger logger)
    {
        this.logger = logger;
    }

    public Rater Create(PolicyModel dto)
    {
        var defaultPolicy = new UnknownPolicy();
        var defaultRater = new UnknownPolicyRater(
            this.logger,
            defaultPolicy);

        var policyFactory = new PolicyFactory();
        var policy = policyFactory.Create(dto);

        try
        {
            var instance = (Rater?)Activator.CreateInstance(
                Type.GetType($"ArdalisRating.Core.PolicyRaters.{dto.Type}PolicyRater")!,
                this.logger,
                policy);

            return instance ?? defaultRater;
        }
        catch
        {
            return defaultRater;
        }
    }
}
