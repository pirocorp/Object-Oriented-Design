using ArdalisRating.Core.Model;

namespace ArdalisRating.Core.Policies;

public class LandPolicy : Policy
{
    public LandPolicy(
        string address,
        decimal size,
        decimal valuation,
        decimal bondAmount)
        : base(PolicyType.Land)
    {
        this.Address = address;
        this.Size = size;
        this.Valuation = valuation;
        this.BondAmount = bondAmount;
    }

    public string Address { get; }

    public decimal Size { get; }

    public decimal Valuation { get; }

    public decimal BondAmount { get; }
}
