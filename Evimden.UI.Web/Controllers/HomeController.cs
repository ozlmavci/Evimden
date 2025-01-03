using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Evimden.UI.Web.Models;

namespace Evimden.UI.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult SSS()
    {
        return View();
    }
    public IActionResult TermsAndConditions()
    {
        return View();
    }

    public IActionResult ShippingInformation()
    {
        return View();
    }
}
