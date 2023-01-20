namespace DomainEvents.Handlers;

using System.Threading;
using System.Threading.Tasks;

using DomainEvents.Events;

using MediatR;

public class NotifyUiAppointmentConfirmed : INotificationHandler<AppointmentConfirmed>
{
    public Task Handle(AppointmentConfirmed notification, CancellationToken cancellationToken)
    {
        ConsoleWriter.FromUiEventHandlers(
            "[UI] User Interface informed appointment for {0} confirmed at {1}",
            notification.Appointment.EmailAddress,
            notification.Appointment.ConfirmationReceivedDate.ToString());

        return Task.CompletedTask;
    }
}
