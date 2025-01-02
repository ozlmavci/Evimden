using AutoMapper;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.IdentityServices
{
    public class UserTokenService : Service<CustomUserToken, CustomUserTokenDto>, IUserTokenService
    {
        public UserTokenService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomUserToken> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
