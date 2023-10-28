using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Avans.GameNight.Core.Domain.Interfaces;
using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Core.DomainServices.Interfaces;

namespace Avans.GameNight.App.Controllers
{
    public class BoardGameNightController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBoardGameNightPlayerRepository _boardGameNightPlayerRepo;
        private readonly IPlayerRepository _playerRepo;
        private IBoardGameNightService _boardgameNightService;


        public BoardGameNightController(UserManager<
            IdentityUser> userManager, IPlayerRepository playerRepo, IBoardGameNightPlayerRepository boardGameNightPlayerRepo,
            IBoardGameNightService boardgamenightService)
        {
            _userManager = userManager;
            _boardGameNightPlayerRepo = boardGameNightPlayerRepo;
            _playerRepo = playerRepo;
            _boardgameNightService = boardgamenightService;

        }


        // GET: BoardGameNightController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var boardGameNights = await _boardgameNightService.GetBoardGameNights();
            return View(boardGameNights);
        }
        //GET MyBoardGames
        [HttpGet]
        public async Task<IActionResult> MyBoardGameNights()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var myBoardGames = await _boardgameNightService.GetBoardGameNightsByHost(user.Email);

                return View(myBoardGames);
            }

            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }
        }

        public ActionResult AccesDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddBoardGame([FromQuery] string nameNight)
        {
            var boardGameNight = await _boardgameNightService.GetBoardGameNightByName(nameNight);
            var boardGames = await _boardgameNightService.GetBoardGameNightBoardGames();
            ViewBag.BoardGames = boardGames;
            ViewBag.NameNightBag = boardGameNight.NameNight;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddBoardGame([FromQuery] string nameNight,
            BoardGameNightBoardGame boardGameNightBoardGame)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var BoardGameNight = await _boardgameNightService.GetBoardGameNightByName(nameNight);
                var boardGames = await _boardgameNightService.GetBoardGameNightBoardGames();

                ViewBag.BoardGames = boardGames;


                if (user.Email != BoardGameNight.Host)
                {
                    throw new Exception("Youre not the Owner!");
                }

                var newBoardGame = new BoardGameNightBoardGame()
                {
                    BoardGameNameGame = boardGameNightBoardGame.BoardGameNameGame,
                    BoardGameNightNameNight = BoardGameNight.NameNight,
                };

                var oldBoardGame =
                    await _boardgameNightService.GetBoardGameByName(newBoardGame.BoardGameNameGame);

                var boardGameExists = oldBoardGame.FirstOrDefault(bgnp => bgnp.BoardGameNightNameNight == nameNight);
                if (boardGameExists != null)
                {
                    throw new Exception("BoardGame already added");
                }


                if (BoardGameNight.BoardGameNightBoardGame == null ||
                    !BoardGameNight.BoardGameNightBoardGame.Contains(newBoardGame))
                {
                    BoardGameNight.BoardGameNightBoardGame?.Add(newBoardGame);
                    await _boardgameNightService.UpdateBoardGameNightByBoardGameNight(BoardGameNight);
                    await _boardgameNightService.AddGameNightBoardGame(newBoardGame);
                }

                TempData["SuccessMessage"] = "Successfully Added: " + newBoardGame.BoardGameNameGame;
                return RedirectToAction("MyBoardGameNights");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error " + ex.Message;
                return RedirectToAction("MyBoardGameNights");
            }
        }

        //JOIN: 
        [HttpPost]
        public async Task<IActionResult> Join(string nameNight)
        {

            try
            {
                var user = await _userManager.GetUserAsync(User);
                var player1 = await _playerRepo.GetPlayerByMailAdress(user.Email);
                var gameNight = await _boardgameNightService.GetBoardGameNightByName(nameNight);
                var oldPlayer = await _boardGameNightPlayerRepo.GetBoardGameNightPlayersByName(user.Email);


                if (player1 == null)
                {
                    throw new Exception("Player is null");
                }

                if (user.Email == gameNight.Host)
                {
                    throw new Exception("Cannot join own GameNight");
                }


                var playerExists = oldPlayer.FirstOrDefault(bgnp => bgnp.BoardGameNightNameNight == nameNight);
                if (playerExists != null)
                {
                    throw new Exception("Youre already in this GameNight");
                }

                if (ModelState.IsValid)
                {
                    if (gameNight.TotalPlayers + 1 > gameNight.MaxPlayers)
                    {
                        throw new Exception("GameNight is full");
                    }

                    gameNight.TotalPlayers = gameNight.TotalPlayers + 1;

                    //BoardGameNightPlayer maken
                    var newPlayer = new BoardGameNightPlayer()
                    {
                        PlayerMailAddress = user.Email,
                        BoardGameNightNameNight = gameNight.NameNight,
                    };


                    if (gameNight.BoardGameNightPlayer.Contains(newPlayer))
                    {
                        throw new Exception("Already in this gamenight");
                    }

                    if ((gameNight.BoardGameNightPlayer == null) || !gameNight.BoardGameNightPlayer.Contains(newPlayer))
                    {
                        gameNight.BoardGameNightPlayer?.Add(newPlayer);
                        await _boardgameNightService.UpdateBoardGameNightByBoardGameNight(gameNight);
                        await _boardGameNightPlayerRepo.AddBoardGameNightPlayer(newPlayer);
                    }
                }

                TempData["SuccessMessage"] = "Successfully joined: " + gameNight.NameNight;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index");
            }
        }

        //Leave: 
        [HttpPost]
        public async Task<IActionResult> Leave(string nameNight)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var gameNight = await _boardgameNightService.GetBoardGameNightByName(nameNight);
                var oldPlayer = await _boardGameNightPlayerRepo.GetBoardGameNightPlayersByName(user.Email);

                if (user.Email == gameNight.Host)
                {
                    throw new Exception("Cannot leave your own gamenight");
                }


                if (ModelState.IsValid)
                {
                    if (gameNight.TotalPlayers - 1 < 0)
                    {
                        throw new Exception("GameNight cannot be empty");
                    }

                    var playerExists = oldPlayer.FirstOrDefault(bgnp => bgnp.BoardGameNightNameNight == nameNight);
                    if (playerExists != null)
                    {
                        gameNight.TotalPlayers = gameNight.TotalPlayers - 1;

                        await _boardgameNightService.UpdateBoardGameNightByBoardGameNight(gameNight);
                        await _boardGameNightPlayerRepo.DestroyBoardGameNightPlayer(playerExists);
                    }

                    await _boardgameNightService.UpdateBoardGameNightByBoardGameNight(gameNight);
                }


                TempData["SuccessMessage"] = "Successfully leaved: " + gameNight.NameNight;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var player = await _playerRepo.GetPlayerByMailAdress(user.Email);
            var BoardGames = await _boardgameNightService.GetBoardGameNightBoardGames();

            ViewBag.BoardGamesList = BoardGames;

            if (player.role == Role.HOST)
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
                boardGameNight.Host = user.Email;
                boardGameNight.TotalPlayers = 1;

                //boardGameNight.BoardGameNightBoardGame = ViewBag.BoardGamesList;
                await _boardgameNightService.AddBoardGameNight(boardGameNight);
                

                TempData["SuccessMessage"] = "Successfully Created BoardGameNight: " + boardGameNight.NameNight;
                return RedirectToAction("Index");
            }
            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }
        }
    }
}