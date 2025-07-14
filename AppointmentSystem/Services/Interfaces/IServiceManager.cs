namespace AppointmentSystem.Services.Interfaces
{
    public interface IServiceManager
    {
        IRoleService RoleService { get; }
        IUserService UserService { get; }
    }
}