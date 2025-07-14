using AppointmentSystem.Models;

namespace AppointmentSystem.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<IEnumerable<Appointment>> GetAllApointmentsByDoctorId(int DoctorId);
        Task<IEnumerable<Appointment>> GetAllApointmentsByPatientId(int PatientId);
        Task<Appointment?> GetAppointmentByIdAsync(int AppointmentId);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
    }
}