namespace ArdalisRating.Core.Policies;

using ArdalisRating.Core.Model;

public class AutoPolicy : Policy
{
    public AutoPolicy(
        string make,
        string model,
        int year,
        int miles,
        decimal deductible)
        : base(PolicyType.Auto)
    {
        this.Make = make;
        this.Model = model;
        this.Year = year;
        this.Miles = miles;
        this.Deductible = deductible;
    }

    public string Make { get; }

    public string Model { get; }

    public int Year { get; }

    public int Miles { get; }

    public decimal Deductible { get; }
}
