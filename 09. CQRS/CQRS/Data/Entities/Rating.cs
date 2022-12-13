namespace CQRS.Data.Entities;

public class Rating : EntityBase
{
    private Rating(double score)
    {
        this.Score = score;
    }

    public double Score { get; set; }

    public static Rating Create(double score)
        => new (score);
}
