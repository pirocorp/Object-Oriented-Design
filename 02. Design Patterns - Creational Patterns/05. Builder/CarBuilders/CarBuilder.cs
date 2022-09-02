namespace Builder.CarBuilders;

public abstract class CarBuilder
{
    protected Car Car;

    protected CarBuilder()
    {
        this.Car = new Car();
    }

    public abstract void SetHorsePower();

    public abstract void SetTopSpeed();

    public abstract void SetImpressiveFeature();

    public virtual Car GetCar() => this.Car;
}
