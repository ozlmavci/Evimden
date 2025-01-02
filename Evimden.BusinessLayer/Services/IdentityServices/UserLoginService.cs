using AutoMapper;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.IdentityServices
{
    public class UserLoginService : Service<CustomUserLogin, CustomUserLoginDto>, IUserLoginService
    {
        public UserLoginService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomUserLogin> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}

