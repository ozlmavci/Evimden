using AutoMapper;
using Evimden.BusinessLayer.Interfaces.LocationInterfaces;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.DTOs.LocationDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.LocationServices
{
    public class CountryService : Service<Country, CountryDto>, ICountryService
    {
        public CountryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Country> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
