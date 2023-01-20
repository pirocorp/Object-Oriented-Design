namespace DomainEvents.Handlers;

using System.Threading;
using System.Threading.Tasks;

using DomainEvents.Events;

using MediatR;

public class NotifyUiAppointmentCreated : INotificationHandler<AppointmentCreated>
{
    public Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
    {
        var emailAddress = notification.Appointment.EmailAddress;

        ConsoleWriter.FromUiEventHandlers(
            "[UI] User Interface informed appointment created for {0}", 
            emailAddress);

        return Task.CompletedTask;
    }
}
