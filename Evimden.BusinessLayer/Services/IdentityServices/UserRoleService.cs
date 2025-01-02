using AutoMapper;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.IdentityServices
{
    public class UserRoleService : Service<CustomUserRole, CustomUserRoleDto>, IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomUserRole> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
