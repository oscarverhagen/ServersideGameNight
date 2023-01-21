using Microsoft.AspNetCore.Mvc;
using ServersideGameNight.Models;
using System.Diagnostics;

namespace ServersideGameNight.Controllers
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