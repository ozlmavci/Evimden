using AutoMapper;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.IdentityServices
{
    public class RoleClaimService : Service<CustomRoleClaim, CustomRoleClaimDto>, IRoleClaimService
    {
        public RoleClaimService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomRoleClaim> logger) : base(unitOfWork, mapper, logger)
        { 
        }
    }
}
