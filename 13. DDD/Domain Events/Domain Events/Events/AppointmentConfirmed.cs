namespace DomainEvents.Events;

using System;
using DomainEvents.Interfaces;
using Entities;

public class AppointmentConfirmed : IDomainEvent
{
    public AppointmentConfirmed(Appointment appointment, DateTime dateConfirmed)
    {
        this.Appointment = appointment;
        this.DateOccurred = dateConfirmed;
    }

    public AppointmentConfirmed(Appointment appointment) 
        : this(appointment, DateTime.Now)
    {
    }

    public Appointment Appointment { get; set; }

    public DateTime DateOccurred { get; private set; }
}
