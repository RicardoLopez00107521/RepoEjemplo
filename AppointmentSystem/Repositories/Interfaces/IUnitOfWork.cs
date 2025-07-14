namespace AppointmentSystem.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IUserRoleRepository UserRoles { get; }
        IAppointmentRepository Appointments { get; }
        
        Task<int> CompleteAsync();
    }
}