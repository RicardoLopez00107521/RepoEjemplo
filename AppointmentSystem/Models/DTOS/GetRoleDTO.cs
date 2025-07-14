namespace AppointmentSystem.Models.DTOS
{
    public class GetRoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<string> Users { get; set; } = [];
    }
}