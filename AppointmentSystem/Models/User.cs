using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string? Addres { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = [];
        
        public ICollection<Appointment> AppointmentsAsDoctor { get; set; } = [];

        public ICollection<Appointment> AppointmentsAsPatient { get; set; } = [];
    }
}

