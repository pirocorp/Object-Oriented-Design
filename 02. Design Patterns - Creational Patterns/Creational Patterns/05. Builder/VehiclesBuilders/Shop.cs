namespace Builder.VehiclesBuilders;

/// <summary>
/// The 'Director' class
/// </summary>
public class Shop
{
    // Builder uses a complex series of steps
    public void Construct(IVehicleBuilder vehicleBuilder)
    {
        vehicleBuilder.BuildFrame();
        vehicleBuilder.BuildEngine();
        vehicleBuilder.BuildWheels();
        vehicleBuilder.BuildDoors();
    }
}
