using AppointmentSystem.Models;

namespace AppointmentSystem.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task AddUserRoleAsync(UserRole userRole);
        Task RemoveRoleAsync(UserRole userRole);
    }
}