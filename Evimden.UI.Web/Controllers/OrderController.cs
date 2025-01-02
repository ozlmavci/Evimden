using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Evimden.UI.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllAsync();
            return View(orders);
        }

        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDto orderDto)
        {
            await _orderService.AddAsync(orderDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id)
;
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderDto orderDto)
        {
            await _orderService.UpdateAsync(orderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteAsync(id)
;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id)
;
            return View(order);
        }

    }
}