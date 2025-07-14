using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models.DTOS
{
    public class NewUserDTO
    {
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50, ErrorMessage = "FirstName cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(50, ErrorMessage = "LastName cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "PhoneNumber must contain only numbers")]
        public string PhoneNumber { get; set; }

        [MaxLength(50, ErrorMessage = "Address cannot exceed 50 characters")]
        public string Addres { get; set; }
    }
}