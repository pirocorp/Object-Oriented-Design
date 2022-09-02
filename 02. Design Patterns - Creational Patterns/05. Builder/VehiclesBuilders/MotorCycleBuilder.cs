namespace Builder.VehiclesBuilders;

/// <summary>
/// The 'ConcreteBuilder' class
/// </summary>
public class MotorCycleBuilder : IVehicleBuilder
{
    private const VehicleType Type = VehicleType.MotorCycle;

    public MotorCycleBuilder()
    {
        this.Vehicle = new Vehicle(Type);
    }

    public Vehicle Vehicle { get; }

    public void BuildFrame()
        => this.Vehicle[VehiclePart.Frame] = $"{Type} Frame";

    public void BuildEngine()
        => this.Vehicle[VehiclePart.Engine] = "500 cc";

    public void BuildWheels()
        => this.Vehicle[VehiclePart.Wheels] = "2";

    public void BuildDoors()
        => this.Vehicle[VehiclePart.Doors] = "0";
}