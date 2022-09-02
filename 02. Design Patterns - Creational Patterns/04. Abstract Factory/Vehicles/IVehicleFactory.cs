namespace Abstract_Factory.Vehicles;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}