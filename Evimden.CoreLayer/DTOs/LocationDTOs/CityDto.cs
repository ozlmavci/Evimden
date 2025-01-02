using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Concrete.LocationEntities;

namespace Evimden.CoreLayer.DTOs.LocationDTOs
{
    public class CityDto : IDtoModel
    {
        public int CityId { get; set; }
        public int CountryId { get; set; } = 90;
        public string CityName { get; set; }
    }
}
