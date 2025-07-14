using AppointmentSystem.Models.DTOS;
using AppointmentSystem.Repositories.Interfaces;
using AppointmentSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _serviceManager.UserService.GetAllUsersAsync();

            if (!users.Any())
            {
                return NotFound(new { message = "No users found" });
            }

            return Ok(users);
        }

        [HttpPost("newUser")]
        public async Task<IActionResult> CreateUser([FromBody] NewUserDTO newUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _serviceManager.UserService.CreateUserAsync(newUserDto);
            return Ok(new { message = "User created successfully" });
        }
    }
}