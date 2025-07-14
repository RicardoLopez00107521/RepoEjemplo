using AppointmentSystem.Models;

namespace AppointmentSystem.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByRoleName(string RoleName);
        Task AddRoleAsync(Role role);
        Task DeleteRoleAsync(Role role);
    }
}