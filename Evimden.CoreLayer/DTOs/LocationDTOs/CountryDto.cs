using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.LocationDTOs
{
    public class CountryDto : IDtoModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
