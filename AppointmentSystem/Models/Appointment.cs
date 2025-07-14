using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required]
        public string Reason { get; set; } = string.Empty;
        [Required]
        public string Notes { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        [Required]
        public User Doctor { get; set; } = null!;
        public int PatientId { get; set; }
        [Required]
        public User Patient { get; set; } = null!;
    }
}
