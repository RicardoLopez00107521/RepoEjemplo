namespace AppointmentSystem.Models.DTOS
{
    public class GetUserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int PhoneNumber { get; set; }
        public string Addres { get; set; }
        public List<string> Roles { get; set; }  
    }

}