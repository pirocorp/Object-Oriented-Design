namespace Builder.VehiclesBuilders;

/// <summary>
/// The 'Builder' abstract 'class'
/// </summary>
public interface IVehicleBuilder
{
    Vehicle Vehicle { get; }

    void BuildFrame();

    void BuildEngine();

    void BuildWheels();

    void BuildDoors();
}