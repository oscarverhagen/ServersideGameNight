using System.Diagnostics;
using Avans.GameNight.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans.GameNight.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult LoginIndex()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult CreateGame()
        {
            return View();
        }
        public IActionResult JoinGame()
        {
            return View();
        }
        public IActionResult Login()
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