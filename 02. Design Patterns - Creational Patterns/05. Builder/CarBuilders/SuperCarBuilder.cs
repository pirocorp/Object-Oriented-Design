namespace Builder.CarBuilders;

public class SuperCarBuilder : CarBuilder
{
    public override void SetHorsePower() => this.Car.HorsePower = 1640;

    public override void SetTopSpeed() => this.Car.TopSpeedKmh = 600;

    public override void SetImpressiveFeature() => this.Car.MostImpressiveFeature = "Can Fly";
}
