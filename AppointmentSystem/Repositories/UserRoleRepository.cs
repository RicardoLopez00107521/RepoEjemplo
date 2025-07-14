using AppointmentSystem.Data;
using AppointmentSystem.Models;
using AppointmentSystem.Repositories.Interfaces;

namespace AppointmentSystem.Repositories
{
    public class UserRoleRepository(AppointmentSystemDbContext context) : IUserRoleRepository
    {
        private readonly AppointmentSystemDbContext _context = context;
        public async Task AddUserRoleAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }

        public async Task RemoveRoleAsync(UserRole userRole)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
    }
}