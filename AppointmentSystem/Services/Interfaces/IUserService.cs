using AppointmentSystem.Models;
using AppointmentSystem.Models.DTOS;

namespace AppointmentSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int userId);
        Task CreateUserAsync(NewUserDTO newUserDto);
        Task<IEnumerable<GetUserDTO>> GetAllUsersAsync();
    }
}