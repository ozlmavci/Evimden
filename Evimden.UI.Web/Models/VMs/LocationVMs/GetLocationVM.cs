using Evimden.CoreLayer.DTOs.LocationDTOs;

namespace Evimden.UI.Web.Models.VMs.LocationVMs
{
    internal class GetLocationVM
    {
        public List<CityDto>? Cities { get; set; }
        public List<CountryDto>? Countries { get; set; }
        public List<DistrictDto>? Districts { get; set; }
    }
}