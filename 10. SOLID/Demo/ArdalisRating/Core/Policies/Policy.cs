namespace ArdalisRating.Core.Policies;

using Model;

public abstract class Policy
{
    protected Policy(PolicyType type)
    {
        this.Type = type;
    }

    public PolicyType Type { get; }
}
