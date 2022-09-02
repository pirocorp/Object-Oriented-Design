namespace Factory_Method.Fans
{
    public interface IFanFactory
    {
        IFan CreateFan(FanType type);
    }
}
