namespace Builder.CarBuilders;

public class CarProvider
{
    public Car Build(CarBuilder builder)
    {
        builder.SetHorsePower();

        builder.SetTopSpeed();

        builder.SetImpressiveFeature();

        return builder.GetCar();
    }
}
