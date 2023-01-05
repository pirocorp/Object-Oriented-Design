namespace ArdalisRating.Core.PolicyRaters;

using System;
using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Policies;

public class LifePolicyRater : Rater
{
    public LifePolicyRater(
        ILogger logger,
        LifePolicy policy)
        : base(logger)
    {
        this.Policy = policy;
    }

    private LifePolicy Policy { get; }

    public override decimal Rate()
    {
        this.Logger.Log("Rating LIFE policy...");
        this.Logger.Log("Validating policy.");

        if (this.Policy.DateOfBirth == DateTime.MinValue)
        {
            this.Logger.Log("Life policy must include Date of Birth.");
            return 0;
        }
        if (this.Policy.DateOfBirth < DateTime.Today.AddYears(-100))
        {
            this.Logger.Log("Centenarians are not eligible for coverage.");
            return 0;
        }
        if (this.Policy.Amount == 0)
        {
            this.Logger.Log("Life policy must include an Amount.");
            return 0;
        }
        var age = DateTime.Today.Year - this.Policy.DateOfBirth.Year;
        if (this.Policy.DateOfBirth.Month == DateTime.Today.Month &&
            DateTime.Today.Day < this.Policy.DateOfBirth.Day ||
            DateTime.Today.Month < this.Policy.DateOfBirth.Month)
        {
            age--;
        }

        var baseRate = this.Policy.Amount * age / 200;

        if (this.Policy.IsSmoker)
        {
            baseRate *= 2;
        }

        return baseRate;
    }
}
