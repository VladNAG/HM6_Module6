using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HM4_M6.Controllers;
using HM4_M6.Models;
using HM4_M6.Filter;

namespace HM4_M6.Controllers
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
            return View();
        }
        [HttpGet]
        public IActionResult ListCar()
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
    }
}