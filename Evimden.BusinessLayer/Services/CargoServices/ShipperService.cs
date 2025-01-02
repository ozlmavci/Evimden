using AutoMapper;
using Evimden.BusinessLayer.Interfaces.CargoInterfaces;
using Evimden.CoreLayer.Concrete.CargoEntities;
using Evimden.CoreLayer.DTOs.CargoDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.CargoServices
{
    public class ShipperService : Service<Shipper, ShipperDto> , IShipperService
    {
        public ShipperService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Shipper> logger) : base(unitOfWork, mapper, logger) 
        {
        }
        
    }
}
