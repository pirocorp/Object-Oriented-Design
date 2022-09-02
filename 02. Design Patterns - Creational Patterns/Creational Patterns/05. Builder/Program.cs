namespace Builder;

using System;
using System.Collections.Generic;
using CarBuilders;
using PersonBuilders;
using VehiclesBuilders;

public static class Program
{
    public static void Main()
    {
        // CarBuildersDemo();

        // PersonBuilderDemo();

        VehiclesDemo();
    }

    private static void CarBuildersDemo()
    {
        var superBuilder = new SuperCarBuilder();
        var notSuperBuilder = new NotSoSuperCarBuilder();

        var provider = new CarProvider();
        var builders = new List<CarBuilders.CarBuilder> { superBuilder, notSuperBuilder };

        foreach (var builder in builders)
        {
            var car = provider.Build(builder);

            Console.WriteLine($"The car requested by {builder.GetType().Name}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Horse Power: {car.HorsePower}");
            Console.WriteLine($"Impressive Feature: {car.MostImpressiveFeature}");
            Console.WriteLine($"Top Speed in km/h: {car.TopSpeedKmh}");
            Console.WriteLine();
        }
    }

    private static void PersonBuilderDemo()
    {
        var person = new PersonBuilder()
            .Create("Zdravko", "Zdravkov")
            .Gender(Gender.Male)
            .DateOfBirth(DateOnly.FromDateTime(DateTime.Now))
            .Occupation("C# Full-Stack Developer")
            .Build();

        var person2 = new PersonBuilder()
            .Create("Piroman", "Piromanov")
            .Gender(Gender.Male)
            .DateOfBirth(DateOnly.FromDateTime(DateTime.Now))
            .Occupation("Piroman Corporation")
            .Build();

        Console.WriteLine(person.ToString());
        Console.WriteLine();
        Console.WriteLine(person2.ToString());
    }

    private static void VehiclesDemo()
    {
        var builders = new List<IVehicleBuilder>
        {
            new VehiclesBuilders.CarBuilder(),
            new MotorCycleBuilder(),
            new ScooterBuilder()
        };

        var shop = new Shop();

        foreach (var builder in builders)
        {
            shop.Construct(builder);
            var vehicle = builder.Vehicle;
            vehicle.Show();
        }
    }
}