namespace Abstract_Factory.Vehicles;

using CycleVehicles;
using MotorVehicles;

public class VehicleFactory : AbstractVehicleFactory
{
    private readonly IVehicleFactory factory;
    private readonly VehicleRequirements requirements;

    public VehicleFactory(VehicleRequirements requirements)
    {
        this.factory = requirements.HasEngine
            ? new MotorVehicleFactory()
            : new CycleFactory();

        this.requirements = requirements;
    }

    public override IVehicle Create()
        => this.factory.Create(this.requirements);
}