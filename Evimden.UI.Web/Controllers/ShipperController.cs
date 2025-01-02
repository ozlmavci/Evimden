using Evimden.BusinessLayer.Interfaces.CargoInterfaces;
using Evimden.CoreLayer.DTOs.CargoDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Evimden.UI.Web.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        public async Task<IActionResult> Index()
        {
            var shippers = await _shipperService.GetAllAsync();
            return View(shippers);
        }

        [HttpGet]
        public IActionResult AddShipper()
        {
            var model = new ShipperDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddShipper(ShipperDto shipperDto)
        {
            await _shipperService.AddAsync(shipperDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateShipper(Guid id)
        {
            var shipper = await _shipperService.GetByIdAsync(id);
            return View(shipper);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShipper(ShipperDto shipperDto)
        {
            await _shipperService.UpdateAsync(shipperDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteShipper(Guid id)
        {
            await _shipperService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetShipper(Guid id)
        {
            var shipper = await _shipperService.GetByIdAsync(id);
            return View(shipper);
        }

    }
}
