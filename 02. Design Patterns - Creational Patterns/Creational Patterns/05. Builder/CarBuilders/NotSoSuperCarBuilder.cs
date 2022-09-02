namespace Builder.CarBuilders;

public class NotSoSuperCarBuilder : CarBuilder
{
    public override void SetHorsePower() => this.Car.HorsePower = 120;

    public override void SetTopSpeed() => this.Car.TopSpeedKmh = 150;

    public override void SetImpressiveFeature() => this.Car.MostImpressiveFeature = "Has Air Conditioning";
}