namespace Factory_Method.Vehicles
{
    public static class VehicleFactory
    {
        public static IVehicle Build(int wheelsCount) => wheelsCount switch
        {
            1 => new Unicycle(),
            >= 2 and <= 3 => new Motorbike(),
            4 => new Car(),
            _ => new Truck()
        };
    }
}
