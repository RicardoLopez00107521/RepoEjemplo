using AppointmentSystem.Repositories.Interfaces;
using AppointmentSystem.Services.Interfaces;

namespace AppointmentSystem.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RoleService = new RoleService(unitOfWork);
            UserService = new UserService(unitOfWork);
        }

        public IRoleService RoleService { get; }
        public IUserService UserService { get; }
    }
}
