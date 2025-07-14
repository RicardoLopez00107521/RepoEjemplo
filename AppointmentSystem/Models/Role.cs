using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = null!;

        public ICollection<UserRole> UserRoles { get; set; } = [];
    }
}

