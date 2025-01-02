using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs.ProfileDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProfileServices
{
    public class AddressService : Service<Address, AddressDto>, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Address> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
