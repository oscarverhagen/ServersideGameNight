using Avans.GameNight.Core.DomainServices.Interfaces;
using Avans.GameNight.App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using Avans.GameNight.Core.Domain.Models;

namespace Avans.GameNight.App.Controllers
{
    public class PlayerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPlayerRepository _playerRepo;

        public PlayerController(UserManager<IdentityUser> userManager, IPlayerRepository playerRepo)
        {
            _userManager = userManager;
            _playerRepo = playerRepo;

        }
        [HttpGet]
        public async Task<IActionResult> Index()

        {
            var players = await _playerRepo.GetPlayers();
            // ViewBag.test = players;


            return View(players);
        }
        [HttpGet]
        public async Task<IActionResult> Profile()

        {

            try
            {
                var user = await _userManager.GetUserAsync(User);
                var player = await _playerRepo.GetPlayerByMailAdress(user.Email);



                return this.View(player);
            }
            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }

        }
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            var player = await _playerRepo.GetPlayerByMailAdress(user.Email);
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Player playerTemp)
        {
            if (playerTemp.Adress == null)
            {
                playerTemp.Adress = "";
            }
            if (playerTemp.FoodPreference == null)
            {
                playerTemp.FoodPreference = "";
            }
            if (playerTemp.DrinkPreference == null)
            {
                playerTemp.DrinkPreference = "";
            }
            if (playerTemp.City == null)
            {
                playerTemp.City = "";
            }
            //if (ModelState.IsValid)
            //{
            await _playerRepo.UpdatePlayer(playerTemp);
            //}

            TempData["SuccessMessage"] = "Succes Edit! "+playerTemp.MailAddress;
            return RedirectToAction("Profile", new { MailAdress = playerTemp.MailAddress });

        }
    }
}
