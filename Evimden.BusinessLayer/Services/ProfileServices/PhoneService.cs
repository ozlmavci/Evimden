using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs.ProfileDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProfileServices
{
    public class PhoneService : Service<Phone, PhoneDto>, IPhoneService
    {
        public PhoneService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Phone> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
