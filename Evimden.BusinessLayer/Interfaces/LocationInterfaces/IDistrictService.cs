using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.DTOs.LocationDTOs;

namespace Evimden.BusinessLayer.Interfaces.LocationInterfaces
{
    public interface IDistrictService : IService<District, DistrictDto>
    {
        List<DistrictDto> GetDistrictsByCityId(int cityId);
    }
}
