namespace DomainEvents;

using System;
using System.Threading.Tasks;

using DomainEvents.Interfaces;
using DomainEvents.Repositories;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Services;

public static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Load services");

        var services = ConfigureServices();

        var app = services
            .BuildServiceProvider()
            .GetRequiredService<App>();

        await app.Run();
    }

    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddMediatR(typeof(Program));
        services.AddTransient<AppointmentSchedulingService>();
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<App>();

        return services;
    }
}
