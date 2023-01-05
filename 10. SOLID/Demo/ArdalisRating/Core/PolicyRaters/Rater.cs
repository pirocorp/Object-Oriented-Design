namespace ArdalisRating.Core.PolicyRaters;

using ArdalisRating.Core.Interfaces;

public abstract class Rater
{
    protected Rater(
        ILogger logger)
    {
        this.Logger = logger;
    }
    
    protected ILogger Logger { get; }

    public abstract decimal Rate();
}
