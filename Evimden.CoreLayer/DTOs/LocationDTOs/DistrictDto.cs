using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.LocationDTOs
{
    public class DistrictDto : IDtoModel
    {
        public int DistrictId { get; set; }
        public int CityId { get; set; } = 90;
        public int CountryId { get; set; }
        public string DistrictName { get; set; }
    }
}
