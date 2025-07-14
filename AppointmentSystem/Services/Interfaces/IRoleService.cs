using AppointmentSystem.Models;
using AppointmentSystem.Models.DTOS;

namespace AppointmentSystem.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetRoleByRoleNameAsync(string RoleName);
        Task<IEnumerable<GetRoleDTO>> GetAllRolesAsync();
        Task<GetRoleDTO?> ShowRoleByRoleNameDTO(string RoleName);
        Task DeleteRole(Role role);
        Task AddRole(string roleName);
        Task AddUserRole(User user, Role role);
    }
}