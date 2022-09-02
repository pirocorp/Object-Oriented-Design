namespace Builder.VehiclesBuilders;

/// <summary>
/// The 'ConcreteBuilder' class
/// </summary>
public class CarBuilder : IVehicleBuilder
{
    private const VehicleType Type = VehicleType.Car;

    public CarBuilder()
    {
        this.Vehicle = new Vehicle(Type);
    }

    public Vehicle Vehicle { get; }

    public void BuildFrame()
        => this.Vehicle[VehiclePart.Frame] = $"{Type} Frame";

    public void BuildEngine()
        => this.Vehicle[VehiclePart.Engine] = "2500 cc";

    public void BuildWheels()
        => this.Vehicle[VehiclePart.Wheels] = "4";

    public void BuildDoors()
        => this.Vehicle[VehiclePart.Doors] = "4";
}
