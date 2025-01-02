using AutoMapper;
using Evimden.BusinessLayer.Interfaces.LocationInterfaces;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.DTOs.LocationDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Evimden.BusinessLayer.Services.LocationServices
{
    public class DistrictService : Service<District, DistrictDto>, IDistrictService
    {
        public DistrictService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<District> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public List<DistrictDto> GetDistrictsByCityId(int cityId)
        {
            try
            {
                var districts = _unitOfWork.Repository<District>().Where(d => d.CityId == cityId).ToList();
                if (!districts.Any())
                {
                    _logger.LogWarning($"{cityId} şehir için ilçe kaydı bulunamadı.");
                    return null;
                }
                return _mapper.Map<List<DistrictDto>>(districts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetDistrictsByCityId: {cityId} şehir için ilçe getirilirken hata oluştu.");
                throw ex;
            }
        }
    }
}
