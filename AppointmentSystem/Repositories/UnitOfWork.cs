using AppointmentSystem.Data;
using AppointmentSystem.Repositories.Interfaces;

namespace AppointmentSystem.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppointmentSystemDbContext _context;

        public UnitOfWork(AppointmentSystemDbContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            UserRoles = new UserRoleRepository(_context);
            Appointments = new AppointmentRepository(_context);
        }

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IUserRoleRepository UserRoles { get; }
        public IAppointmentRepository Appointments { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
