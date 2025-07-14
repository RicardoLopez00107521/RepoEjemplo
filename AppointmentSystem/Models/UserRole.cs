using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class UserRole
    {
        public int UserId { get; set; }

        [Required]
        public User User { get; set; } = null!;

        public int RoleId { get; set; }

        [Required]
        public Role Role { get; set; } = null!;
    }
}

