using AutoMapper;
using Evimden.BusinessLayer.Interfaces.LocationInterfaces;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.DTOs.LocationDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.LocationServices
{
    public class CityService : Service<City, CityDto>, ICityService
    {
        public CityService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<City> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
