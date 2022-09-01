namespace Abstract_Factory;

using System;
using System.Collections.Generic;

using Abstract_Factory.Accounts;
using Abstract_Factory.Vehicles;

public static class Program
{
    public static void Main()
    {
        // AccountsDemo();

        VehiclesDemo();
    }

    private static void AccountsDemo()
    {
        var accountNumbers = new List<string>()
        {
            "CITI-456",
            "National-987",
            "CHASE-222",
            "Invalid-334",
        };

        foreach (var accNumber in accountNumbers)
        {
            var abstractFactory = CreditUnionFactoryProvider.GetCreditUnionFactory(accNumber);

            if (abstractFactory == null)
            {
                Console.WriteLine($"The account number {accNumber} is invalid");
                continue;
            }

            var loan = abstractFactory.CreateLoanAccount();
            var savings = abstractFactory.CreateSavingsAccount();
        }
    }

    private static void VehiclesDemo()
    {
        var requirements = ReadRequirements();

        var vehicle = GetVehicle(requirements);
            
        Console.WriteLine(vehicle.GetType().Name);
    }

    private static VehicleRequirements ReadRequirements()
    {
        var requirements = new VehicleRequirements();

        Console.WriteLine("To Build a Vehicle answer the following questions");
        Console.WriteLine("How many wheels do you have ");

        if (!int.TryParse(Console.ReadLine(), out var wheelsCount))
        {
            wheelsCount = 1;
        }

        requirements.NumberOfWheels = wheelsCount;

        Console.WriteLine("Do you have an engine ( Y/n )");

        var engine = Console.ReadLine() ?? string.Empty;
        requirements.HasEngine = Confirmation(engine.ToLower());

        Console.WriteLine("How many passengers will you be carrying ?  (1 - 10)");

        if (!int.TryParse(Console.ReadLine(), out var passengerCount))
        {
            passengerCount = 1;
        }

        requirements.Passengers = passengerCount;

        Console.WriteLine("Will you be carrying cargo");

        var cargo = Console.ReadLine() ?? string.Empty;
        requirements.HasCargo = Confirmation(cargo.ToLower());

        return requirements;
    }

    private static bool Confirmation(string input)
        => input switch
        {
            "y" => true,
            _ => false
        };

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        var factory = new VehicleFactory(requirements);
        return factory.Create();
    }
}
