namespace DomainEvents.Handlers;

using System.Threading;
using System.Threading.Tasks;

using DomainEvents.Events;

using MediatR;

public class NotifyUserAppointmentCreated : INotificationHandler<AppointmentCreated>
{
    public Task Handle(AppointmentCreated notification, CancellationToken cancellationToken)
    {
        var emailAddress = notification.Appointment.EmailAddress;

        ConsoleWriter.FromEmailEventHandlers(
            "[EMAIL] Notification email sent to {0}", 
            emailAddress);

        return Task.CompletedTask;
    }
}
