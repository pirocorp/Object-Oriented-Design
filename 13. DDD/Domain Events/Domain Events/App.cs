﻿namespace DomainEvents;

using System;
using System.Threading.Tasks;

using DomainEvents.Entities;
using DomainEvents.Interfaces;
using DomainEvents.Services;

public class App
{
    private readonly AppointmentSchedulingService appointmentService;
    private readonly IRepository<Appointment> appointmentRepository;

    public App(AppointmentSchedulingService appointmentService,
        IRepository<Appointment> appointmentRepository)
    {
        this.appointmentService = appointmentService;
        this.appointmentRepository = appointmentRepository;
    }

    public async Task Run()
    {
        var testDate = new DateTime(2030, 9, 9, 14, 0, 0);
        Console.WriteLine("App running.");

        Console.WriteLine("Scheduling an appointment with a service.");
        await this.appointmentService.ScheduleAppointment("steve@test1.com");
        Console.WriteLine();

        Console.WriteLine("Creating an appointment with a repository.");
        var appointment = Appointment.Create("steve@test2.com");
        await this.appointmentRepository.Save(appointment);
        Console.WriteLine();

        Console.WriteLine("Confirming an appointment.");
        appointment.Confirm(testDate);
        await this.appointmentRepository.Save(appointment);
        Console.WriteLine();

        Console.WriteLine("Application done.");
        Console.ReadLine();
    }
}
