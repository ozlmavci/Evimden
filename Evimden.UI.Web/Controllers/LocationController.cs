using Evimden.BusinessLayer.Interfaces.LocationInterfaces;
using Evimden.CoreLayer.DTOs.LocationDTOs;
using Evimden.UI.Web.Models.VMs.LocationVMs;
using Microsoft.AspNetCore.Mvc;

namespace Evimden.UI.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IDistrictService _districtService;


        public LocationController(ICityService cityService, ICountryService countryService, IDistrictService districtService)
        {
            _cityService = cityService;
            _countryService = countryService;
            _districtService = districtService;
        }


        public async Task<IActionResult> Index()
        {
            GetLocationVM getLocationVM = new GetLocationVM
            {
                Cities = await _cityService.GetAllAsync(),
                Countries = await _countryService.GetAllAsync(),
                Districts = await _districtService.GetAllAsync()
            };
            return View(getLocationVM);
        }


        #region City Operations
        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            await _cityService.AddAsync(cityDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCity(Guid id)
        {
            var city = await _cityService.GetByIdAsync(id)
;
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCity(CityDto cityDto)
        {
            await _cityService.UpdateAsync(cityDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCity(Guid id)
        {
            await _cityService.DeleteAsync(id)
;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCity(Guid id)
        {
            var city = await _cityService.GetByIdAsync(id)
;
            return View(city);
        }
        #endregion

        #region Country Operations

        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(CountryDto countryDto)
        {
            await _countryService.AddAsync(countryDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCountry(CountryDto countryDto)
        {
            await _countryService.UpdateAsync(countryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            await _countryService.DeleteAsync(id)
       ;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCountry(Guid id)
        {
            var country = await _countryService.GetByIdAsync(id)
       ;
            return View(country);
        }

        #endregion

        #region District Operations

        [HttpGet]
        public IActionResult AddDistrict()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDistrict(DistrictDto districtDto)
        {
            await _districtService.AddAsync(districtDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDistrict(DistrictDto districtDto)
        {
            await _districtService.UpdateAsync(districtDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDistrict(Guid id)
        {
            await _districtService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetDistrict(Guid id)
        {
            var district = await _districtService.GetByIdAsync(id);
            return View(district);
        }
        #endregion
    }
}
