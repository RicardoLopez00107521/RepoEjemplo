using AppointmentSystem.Data;
using AppointmentSystem.Models;
using AppointmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Repositories
{
    public class AppointmentRepository(AppointmentSystemDbContext context) : IAppointmentRepository
    {
        private readonly AppointmentSystemDbContext _context = context;

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments
                .Include(d => d.Doctor.FirstName)
                .Include(p => p.Patient.FirstName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllApointmentsByDoctorId(int DoctorId)
        {
            return await _context.Appointments
                .Include(d => d.Doctor.FirstName)
                .Include(p => p.Patient.FirstName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllApointmentsByPatientId(int PatientId)
        {
            return await _context.Appointments
                .Include(d => d.Doctor.FirstName)
                .Include(p => p.Patient.FirstName)
                .ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int AppointmentId)
        {
            return await _context.Appointments
                .Include(d => d.Doctor.FirstName)
                .Include(p => p.Patient.FirstName)
                .FirstOrDefaultAsync();
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}