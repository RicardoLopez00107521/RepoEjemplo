using AppointmentSystem.Models;
using AppointmentSystem.Services.Interfaces;
using AppointmentSystem.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public RoleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _serviceManager.RoleService.GetAllRolesAsync();

            if (roles == null)
            {
                return ResponseBuilder.NotFound("Any roles founded!");
            }

            return ResponseBuilder.Ok("Roles founded: ", roles);
        }

        [HttpGet("getRoleByName/{RoleName}")]
        public async Task<IActionResult> GetRoleByName(string RoleName)
        {
            var role = await _serviceManager.RoleService.ShowRoleByRoleNameDTO(RoleName);

            if (role == null)
            {
                return ResponseBuilder.NotFound("Role " + RoleName + " not found!");
            }

            return ResponseBuilder.Ok("Role founded: ", role.RoleName);
        }

        [HttpDelete("deleteRoleByName/{RoleName}")]
        public async Task<IActionResult> DelteRoleByRoleName(string RoleName)
        {
            var findRole = await _serviceManager.RoleService.GetRoleByRoleNameAsync(RoleName);

            if (findRole == null)
            {
                return ResponseBuilder.NotFound("Role not found!");
            }

            await _serviceManager.RoleService.DeleteRole(findRole);

            return ResponseBuilder.Ok("Role removed, succesfuly!");
        }

        [HttpPost("addRole/{RoleName}")]
        public async Task<IActionResult> AddRole(string RoleName)
        {

            var findRole = await _serviceManager.RoleService.GetRoleByRoleNameAsync(RoleName);

            if (findRole != null)
            {
                return ResponseBuilder.Conflict("Role already exist!");
            }

            await _serviceManager.RoleService.AddRole(RoleName);

            return ResponseBuilder.Ok("Role added, succesfuly!");
        }

        [HttpPatch("addUserRole/{UserId}/{RoleName}")]
        public async Task<IActionResult> AddUserRole(int UserId, string RoleName)
        {
            var findUser = await _serviceManager.UserService.GetUserById(UserId);

            if (findUser == null)
            {
                return ResponseBuilder.NotFound("User not found!");
            }

            var findRole = await _serviceManager.RoleService.GetRoleByRoleNameAsync(RoleName);

            if (findRole == null)
            {
                return ResponseBuilder.NotFound("Role not found!");
            }

            await _serviceManager.RoleService.AddUserRole(findUser, findRole);

            return ResponseBuilder.Ok("User role added, succesfuly!");
        }
    }
}