using Microsoft.AspNetCore.Mvc;

namespace Evimden.UI.Web.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
