using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models.DTOS
{
    public class NewRoleDTO
    {

        [Required(ErrorMessage = "RoleName cant be empty")]
        [MaxLength(50, ErrorMessage = "RoleName cannot exceed 50 characters")]
        public string RoleName { get; set; }
    }
}