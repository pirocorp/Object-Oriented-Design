namespace Factory_Method
{
    using System;
    using Documents;
    using Fans;
    using Vehicles;

    public static class Program
    {
        public static void Main()
        {
            // FanDemo();
            // VehiclesDemo();
            DocumentsDemo();
        }

        private static void FanDemo()
        {
            var fanFactory = new FanFactory();

            var ceilingFan = fanFactory.CreateFan(FanType.CeilingFan);
            var tableFan = fanFactory.CreateFan(FanType.TableFan);

            ceilingFan.SwitchOn();
            tableFan.SwitchOff();

            Console.WriteLine(ceilingFan.GetState());
            Console.WriteLine(tableFan.GetState());
        }

        private static void VehiclesDemo()
        {
            Console.WriteLine("Enter a number of wheels between 1 and 12 to build a vehicle and press enter");
           
            var wheels = int.Parse(Console.ReadLine() ?? "0");
            var vehicle = VehicleFactory.Build(wheels);

            Console.WriteLine($"You built a {vehicle.GetType().Name}");
        }

        private static void DocumentsDemo()
        {
            // Note: constructors call Factory Method
            var documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Report();

            // Display document pages
            foreach (var document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");

                foreach (var page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }
        }
    }
}