namespace Builder.VehiclesBuilders;

public class ScooterBuilder : IVehicleBuilder
{
    private const VehicleType Type = VehicleType.Scooter;

    public ScooterBuilder()
    {
        this.Vehicle = new Vehicle(Type);
    }

    public Vehicle Vehicle { get; }

    public void BuildFrame()
        => this.Vehicle[VehiclePart.Frame] = $"{Type} Frame";

    public void BuildEngine()
        => this.Vehicle[VehiclePart.Engine] = "50 cc";

    public void BuildWheels()
        => this.Vehicle[VehiclePart.Wheels] = "2";

    public void BuildDoors()
        => this.Vehicle[VehiclePart.Doors] = "0";
}
