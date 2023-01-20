namespace DomainEvents.Services;

using System.Threading.Tasks;

using DomainEvents.Entities;
using DomainEvents.Interfaces;

public class AppointmentSchedulingService
{
    private readonly IRepository<Appointment> appointmentRepository;
    public AppointmentSchedulingService(IRepository<Appointment> appointmentRepository)
    {
        this.appointmentRepository = appointmentRepository;
    }

    public Task ScheduleAppointment(string email)
    {
        var appointment = Appointment.Create(email);
        return this.appointmentRepository.Save(appointment);
    }
}
