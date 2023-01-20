namespace DomainEvents.Entities;

using System;
using System.Collections.Generic;

using DomainEvents.Interfaces;

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

        // send an email - pretend there's 5-10 lines of code here to send an email
        // example:
        // using var client = new SmtpClient(_config.Hostname, _config.Port);
        // var mailMessage = new MailMessage();
        // mailMessage.To.Add(to);
        // mailMessage.From = new MailAddress(from);
        // mailMessage.Subject = subject;
        // mailMessage.IsBodyHtml = true;
        // mailMessage.Body = body;
        // client.Send(mailMessage);
        Console.WriteLine("Notification email sent to {0}", emailAddress);

        // update the user interface
        // pretend some code here pops up a notification in the UI
        // or sends a message via Blazor
        // Example:
        // string message = $"User {emailAddress} created an appointment.";
        // await HubContext.Clients.All.SendAsync("ReceiveMessage", message); 
        Console.WriteLine("User Interface informed appointment created for {0}", emailAddress);

        return appointment;
    }

    public void Confirm(DateTime dateConfirmed)
    {
        this.ConfirmationReceivedDate = dateConfirmed;

        Console.WriteLine(
            "[UI] User Interface informed appointment for {0} confirmed at {1}", 
            this.EmailAddress, 
            this.ConfirmationReceivedDate.ToString());
    }
}
