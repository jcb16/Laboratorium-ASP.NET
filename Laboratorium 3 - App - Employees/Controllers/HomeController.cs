using Laboratorium_3___App___Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium_3___App___Employees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var date = HttpContext.Items[LastVisitCookie.CookieName];
            ViewBag.LastVisit = date;
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
    }
}