using Avans.GameNight.App.Models;
using Microsoft.AspNetCore.Mvc;
using Avans.GameNight.Core.DomainServices.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace Avans.GameNight.App.Controllers
{
    public class BoardGameNightController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBoardGameNightRepository _boardGameNightRepo;
        private readonly IBoardGameRepository _boardGameRepo;
        private readonly IPlayerRepository _playerRepo;


        public BoardGameNightController(UserManager<IdentityUser> userManager, IBoardGameNightRepository boardGameNightRepo, IPlayerRepository playerRepo, IBoardGameRepository boardGameRepo)
        {
            _userManager = userManager;
            _boardGameNightRepo = boardGameNightRepo;
            _playerRepo= playerRepo;    
            _boardGameRepo = boardGameRepo;

    }
        public ActionResult AccesDenied()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MyBoardGameNights()
        {
            var boardGames = await _boardGameNightRepo.GetBoardGameNights();




            return View(boardGames);
        }

        // GET: BoardGameNightController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var BoardGames = await _boardGameRepo.GetBoardGames();
            ViewBag.BoardGamesList = BoardGames;

            var players = await _playerRepo.GetPlayers();
            ViewBag.Players = players;

            var boardGameNights = await _boardGameNightRepo.GetBoardGameNights();
            return View(boardGameNights);
        }

        //JOIN: 
        [HttpPost]
        public async Task<IActionResult> Index(BoardGameNight a)
        {


            try
            {
                var user = await _userManager.GetUserAsync(User);

                a = await _boardGameNightRepo.GetBoardGameNightByName("oscar");

                a.TotalPlayers = 2;


                return RedirectToAction("Index");


            }
            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            var user = await _userManager.GetUserAsync(User);
            var player = await _playerRepo.GetPlayerByMailAdress(user.Email);

            var BoardGames = await _boardGameRepo.GetBoardGames();


            ViewBag.BoardGamesList = BoardGames;

            if (player.role == Models.Role.HOST)
            {
               
                return View();
            }
            else
            {
                return RedirectToAction("AccesDenied");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(BoardGameNight boardGameNight)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User); 
                var player = await _playerRepo.GetPlayerByMailAdress(user.Email);

                boardGameNight.Host = user.Email;
                boardGameNight.TotalPlayers = 1;
                //boardGameNight.Boardgames = ViewBag.BoardGamesList;
                //if (ModelState.IsValid)
                //{
                    await _boardGameNightRepo.AddBoardGameNight(boardGameNight);
                //}

                return RedirectToAction("Index");
              

            }
            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }


        }


    }
}
