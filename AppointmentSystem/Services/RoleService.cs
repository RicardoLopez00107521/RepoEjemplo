using AppointmentSystem.Models;
using AppointmentSystem.Models.DTOS;
using AppointmentSystem.Repositories.Interfaces;
using AppointmentSystem.Services.Interfaces;

namespace AppointmentSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Role> GetRoleByRoleNameAsync(string RoleName)
        {
            return await _unitOfWork.Roles.GetRoleByRoleName(RoleName);
        }
        public async Task<IEnumerable<GetRoleDTO>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.Roles.GetAllRolesAsync();

            return roles.Select(role => new GetRoleDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Users = role.UserRoles.Select(ur => ur.User.FirstName).ToList()
            });
        }
        public async Task<GetRoleDTO?> ShowRoleByRoleNameDTO(string RoleName)
        {
            var getRole = await _unitOfWork.Roles.GetRoleByRoleName(RoleName);

            if (getRole == null)
            {
                return null;
            }

            GetRoleDTO role = new()
            {
                RoleId = getRole.RoleId,
                RoleName = getRole.RoleName,
                Users = getRole.UserRoles.Select(ur => ur.User.FirstName).ToList()
            };

            return role;
        }
        public async Task DeleteRole(Role role)
        {
            await _unitOfWork.Roles.DeleteRoleAsync(role);
            await _unitOfWork.CompleteAsync();
        }
        public async Task AddRole(string roleName)
        {
            var newRole = new Role
            {
                RoleName = roleName
            };

            await _unitOfWork.Roles.AddRoleAsync(newRole);
            await _unitOfWork.CompleteAsync();
        }
        public async Task AddUserRole(User user, Role role)
        {
            var newUserRole = new UserRole
            {
                UserId = user.UserId,
                RoleId = role.RoleId
            };

            await _unitOfWork.UserRoles.AddUserRoleAsync(newUserRole);
            await _unitOfWork.CompleteAsync();
        }
    }
}