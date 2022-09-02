namespace Builder.VehiclesBuilders
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Vehicle
    {
        private readonly VehicleType vehicleType;
        private readonly Dictionary<VehiclePart, string> parts;

        public Vehicle(VehicleType vehicleType)
        {
            this.vehicleType = vehicleType;
            this.parts = new Dictionary<VehiclePart, string>();
        }

        public string this[VehiclePart key]
        {
            get => this.parts[key];
            set => this.parts[key] = value;
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", this.vehicleType.ToString());
            Console.WriteLine(" Frame : {0}", this.parts[VehiclePart.Frame]);
            Console.WriteLine(" Engine : {0}", this.parts[VehiclePart.Engine]);
            Console.WriteLine(" #Wheels: {0}", this.parts[VehiclePart.Wheels]);
            Console.WriteLine(" #Doors : {0}", this.parts[VehiclePart.Doors]);
        }
    }
}
