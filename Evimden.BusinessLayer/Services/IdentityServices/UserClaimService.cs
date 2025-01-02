using AutoMapper;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.IdentityServices
{
    public class UserClaimService : Service<CustomUserClaim, CustomUserClaimDto>, IUserClaimService
    {
        public UserClaimService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomUserClaim> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
