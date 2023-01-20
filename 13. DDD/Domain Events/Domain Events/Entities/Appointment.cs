namespace DomainEvents.Entities;

using System;
using System.Collections.Generic;

using DomainEvents.Interfaces;
using Events;

public class Appointment : IEntity
{
    public Guid Id { get; private set; }

    public string EmailAddress { get; private init; }

    public DateTime? ConfirmationReceivedDate { get; private set; }

    public List<IDomainEvent> Events { get; set; }

    protected Appointment() 
        : this(Guid.NewGuid())
    {
    }

    public Appointment(Guid id)
    {
        this.Id = id;

        this.EmailAddress = string.Empty;
        this.Events = new List<IDomainEvent>();
    }

    public static Appointment Create(string emailAddress)
    {
        Console.WriteLine("Appointment::Create()");

        var appointment = new Appointment
        {
            EmailAddress = emailAddress
        };

        appointment.Events.Add(new AppointmentCreated(appointment));

        return appointment;
    }

    public void Confirm(DateTime dateConfirmed)
    {
        this.ConfirmationReceivedDate = dateConfirmed;

        this.Events.Add(new AppointmentConfirmed(this, dateConfirmed));
    }
}
