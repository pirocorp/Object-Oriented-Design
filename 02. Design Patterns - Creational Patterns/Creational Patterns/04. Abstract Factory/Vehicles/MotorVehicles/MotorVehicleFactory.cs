namespace Abstract_Factory.Vehicles.MotorVehicles;

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        if (requirements.Passengers > 1)
        {
            return new Car();
        }

        if (requirements.HasCargo)
        {
            return new Truck();
        }

        switch (requirements.NumberOfWheels)
        {
            case 1:
            case 2:
            case 3:
                return new Motorbike();
            case 4:
                return new Car();
            default:
                return new Truck();
        }
    }
}