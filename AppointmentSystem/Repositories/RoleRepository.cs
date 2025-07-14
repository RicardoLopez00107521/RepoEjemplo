using AppointmentSystem.Data;
using AppointmentSystem.Models;
using AppointmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Repositories
{
    public class RoleRepository(AppointmentSystemDbContext context) : IRoleRepository
    {
        private readonly AppointmentSystemDbContext _context = context;

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.User)
                .ToListAsync();
        }

        public async Task<Role?> GetRoleByRoleName(string RoleName)
        {
            return await _context.Roles
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.User)
                .FirstOrDefaultAsync(r => r.RoleName == RoleName);
        }
        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            
        }

        public async Task DeleteRoleAsync(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}