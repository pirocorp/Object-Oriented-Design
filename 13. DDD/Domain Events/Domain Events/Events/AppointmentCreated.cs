namespace DomainEvents.Events;

using System;

using DomainEvents.Entities;
using DomainEvents.Interfaces;

public class AppointmentCreated : IDomainEvent
{
    public AppointmentCreated(Appointment appointment, DateTime dateCreated)
    {
        this.Appointment = appointment;
        this.DateOccurred = dateCreated;
    }

    public AppointmentCreated(Appointment appointment) : this(appointment, DateTime.Now)
    {
    }

    public Appointment Appointment { get; set; }

    public DateTime DateOccurred { get; private set; }
}   
