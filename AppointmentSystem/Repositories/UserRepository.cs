using AppointmentSystem.Data;
using AppointmentSystem.Models;
using AppointmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Repositories
{
    public class UserRepository(AppointmentSystemDbContext context) : IUserRepository
    {
        private readonly AppointmentSystemDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Include(u => u.AppointmentsAsDoctor)
                .Include(u => u.AppointmentsAsPatient)
                .ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Include(u => u.AppointmentsAsDoctor)
                .Include(u => u.AppointmentsAsPatient)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}