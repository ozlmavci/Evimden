using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.DTOs.ProfileDTOs;
using Evimden.UI.Web.Models.VMs.SellerVMs;
using Microsoft.AspNetCore.Mvc;

namespace Evimden.UI.Web.Controllers
{

    public class SellerController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly ISellerApprovalService _sellerApprovalService;

        public SellerController(ISellerService sellerService, ISellerApprovalService sellerApprovalService)
        {
            _sellerApprovalService = sellerApprovalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSellers()
        {
            var sellers = await _sellerService.GetAllAsync();
            return View(sellers);
        }

        [HttpGet]
        public async Task<IActionResult> GetSeller(Guid id)
        {
            var seller = await _sellerService.GetByIdAsync(id);
            return View(seller);
        }

        [HttpGet]
        public IActionResult RequestToBeSeller()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestToBeSeller(SellerDto sellerDto)
        {
            var seller = await _sellerService.AddAsync(sellerDto);
            await _sellerApprovalService.AddAsync(new SellerApprovalDto()
            {
                SellerApprovalId = Guid.NewGuid(),
                SellerId = seller.SellerId
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SellerBannedStatusChange(Guid id)
        {
            await _sellerService.SellerBannedStatusChangeAsync(id);
            return View();
        }

        [HttpGet] // Satıcı olmak isteyen kullanıcı için 
        public async Task<IActionResult> MySellerRequest(Guid id)
        {
            var request = await _sellerApprovalService.GetApprovalBySellerIdAsync(id);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> PendingSellerRequest()
        {
            var request = await _sellerApprovalService.GetPendingRequests();
            return View(request);
        }

        [HttpGet] // Admin için
        public async Task<IActionResult> PendingSellerRequest(Guid id)
        {
            var request = await _sellerApprovalService.GetByIdAsync(id);
            return View(new ResponseToSellerRequestVM { Dto = request});
        }

        [HttpPost]
        public async Task<IActionResult> PendingSellerRequest(ResponseToSellerRequestVM response)
        {
            await _sellerApprovalService.ResponseToSellerRequest(response.Dto.SellerApprovalId, response.Response);
            return RedirectToAction("Index");
        }
    }
}
