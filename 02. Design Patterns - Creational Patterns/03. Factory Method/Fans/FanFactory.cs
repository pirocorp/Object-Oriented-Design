namespace Factory_Method.Fans
{
    using System;

    public class FanFactory : IFanFactory
    {
        public IFan CreateFan(FanType type) => type switch
            {
                FanType.CeilingFan => new CeilingFan(),
                FanType.TableFan => new TableFan(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported type")
            };
    }
}
