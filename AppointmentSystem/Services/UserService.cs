using AppointmentSystem.Models;
using AppointmentSystem.Models.DTOS;
using AppointmentSystem.Repositories;
using AppointmentSystem.Repositories.Interfaces;
using AppointmentSystem.Services.Interfaces;

namespace AppointmentSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _unitOfWork.Users.GetUserByIdAsync(userId);
        }

        public async Task CreateUserAsync(NewUserDTO newUserDto)
        {
            var newUser = new User
            {
                FirstName = newUserDto.FirstName,
                LastName = newUserDto.LastName,
                PhoneNumber = int.Parse(newUserDto.PhoneNumber),
                Addres = newUserDto.Addres
            };

            await _unitOfWork.Users.AddUserAsync(newUser);
            await _unitOfWork.CompleteAsync();

            var userRole = new UserRole
            {
                UserId = newUser.UserId,
                RoleId = 2
            };

            await _unitOfWork.UserRoles.AddUserRoleAsync(userRole);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<GetUserDTO>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync();

            return users.Select(user => new GetUserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Addres = string.IsNullOrWhiteSpace(user.Addres) ? "Unknown" : user.Addres,
                Roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList()
            });
        }
    }
}