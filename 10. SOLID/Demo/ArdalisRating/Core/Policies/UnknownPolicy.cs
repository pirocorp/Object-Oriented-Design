using ArdalisRating.Core.Model;

namespace ArdalisRating.Core.Policies;

public class UnknownPolicy : Policy
{
    public UnknownPolicy()
        : base(PolicyType.Unknown)
    { }
}
