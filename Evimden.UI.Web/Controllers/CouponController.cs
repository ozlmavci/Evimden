using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Evimden.UI.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            var coupons = await _couponService.GetAllAsync();
            return View(coupons);
        }

        [HttpGet]
        public IActionResult AddCoupon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCoupon(CouponDto couponDto)
        {
            await _couponService.AddAsync(couponDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCoupon(Guid id)
        {
            var coupon = await _couponService.GetByIdAsync(id);
            return View(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCoupon(CouponDto couponDto)
        {
            await _couponService.UpdateAsync(couponDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCoupon(Guid id)
        {
            await _couponService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCoupon(Guid id)
        {
            var coupon = await _couponService.GetByIdAsync(id);
            return View(coupon);
        }
    }
}