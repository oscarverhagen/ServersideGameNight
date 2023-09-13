using Avans.GameNight.App.Models;
using Microsoft.AspNetCore.Mvc;
using Avans.GameNight.Core.DomainServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using Avans.GameNight.Core.Domain.Models;

namespace Avans.GameNight.App.Controllers
{
    public class BoardGameNightController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBoardGameNightRepository _boardGameNightRepo;
        private readonly IBoardGameNightPlayerRepository _boardGameNightPlayerRepo;
        private readonly IBoardGameNightBoardGameRepository _boardGameNightBoardGameRepo;
        private readonly IBoardGameRepository _boardGameRepo;
        private readonly IPlayerRepository _playerRepo;


        public BoardGameNightController(UserManager<IdentityUser> userManager, IBoardGameNightRepository boardGameNightRepo, IPlayerRepository playerRepo, IBoardGameRepository boardGameRepo, IBoardGameNightPlayerRepository boardGameNightPlayerRepo, IBoardGameNightBoardGameRepository BoardGameNightBoardGameRepository)
        {
            _userManager = userManager;
            _boardGameNightRepo = boardGameNightRepo;
            _boardGameNightPlayerRepo = boardGameNightPlayerRepo;
            _playerRepo = playerRepo;    
            _boardGameRepo = boardGameRepo;
            _boardGameNightBoardGameRepo = BoardGameNightBoardGameRepository;

        }
        public ActionResult AccesDenied()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddBoardGame([FromQuery]string nameNight)
        {
          
            var boardGameNight = await _boardGameNightRepo.GetBoardGameNightByName(nameNight);
            var boardGames = await _boardGameRepo.GetBoardGames();
            ViewBag.BoardGames = boardGames;
            ViewBag.NameNightBag = boardGameNight.NameNight;
            return View();
 
        }
        //[Route("/MyBoardGameNights/{nameNight}/{controller}/AddBoardGame")]

        [HttpPost]
        public async Task<IActionResult> AddBoardGame([FromQuery]string nameNight, BoardGameNightBoardGame boardGameNightBoardGame)
        {
            //Boardgame selected meegeven

            //Vervolgends add to BoardGameNightBoardGame
                try
                    {
                var user = await _userManager.GetUserAsync(User);
                var boardGames = await _boardGameRepo.GetBoardGames();
                var BoardGameNight = await _boardGameNightRepo.GetBoardGameNightByName(nameNight);
               


                ViewBag.BoardGames = boardGames;


                if (user.Email != BoardGameNight.Host)
                {
                    throw new Exception("Youre not the Owner!");
                }

               

                //BoardGameNightBoardGame maken
                var newBoardGame = new BoardGameNightBoardGame()
                {
                    BoardGameNameGame = boardGameNightBoardGame.BoardGameNameGame,
                    BoardGameNightNameNight = BoardGameNight.NameNight,
                };

                var oldBoardGame = await _boardGameNightBoardGameRepo.GETBGNByBoardGameName(newBoardGame.BoardGameNameGame);

                var boardGameExists = oldBoardGame.FirstOrDefault(bgnp => bgnp.BoardGameNightNameNight == nameNight);
                if (boardGameExists != null)
                {
                    throw new Exception("BoardGame already added");
                }


                if (BoardGameNight.BoardGameNightBoardGame == null||!BoardGameNight.BoardGameNightBoardGame.Contains(newBoardGame))
                {
                    BoardGameNight.BoardGameNightBoardGame?.Add(newBoardGame);
                    await _boardGameNightRepo.UpdateBoardGameNight(BoardGameNight);
                    await _boardGameNightBoardGameRepo.AddBoardGameNightBoardGame(newBoardGame);
                }

                TempData["SuccessMessage"] = "Successfully Added: "+newBoardGame.BoardGameNameGame;
                return RedirectToAction("MyBoardGameNights");

            }
                catch (Exception ex)
                    {
                TempData["ErrorMessage"] = "Error "+ex.Message;
                return RedirectToAction("MyBoardGameNights");
            }
        }


        //Index MyBoardGames
        [HttpGet]
        public async Task<IActionResult> MyBoardGameNights()
        {
            try
            {
               
                var user = await _userManager.GetUserAsync(User);
               
                var myBoardGames = await _boardGameNightRepo.GetBoardGameNightsByHost(user.Email);

               
                return View(myBoardGames);
            }

            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }


        }
    

        // GET: BoardGameNightController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
         

          

            var boardGameNights = await _boardGameNightRepo.GetBoardGameNights();
            return View(boardGameNights);
        }


     
        //JOIN: 
        [HttpPost]
        public async Task<IActionResult> Join(string nameNight)
        {


            try
            {
                var user = await _userManager.GetUserAsync(User);
                var player1 = await _playerRepo.GetPlayerByMailAdress(user.Email);
                var gameNight = await _boardGameNightRepo.GetBoardGameNightByName(nameNight);
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

                //Nieuwe boardgamenightplayer toevoegen door boardgame id/string op te halen + ingelogde gebruiker
                //Dan via repository deze inserrten in database
                if (ModelState.IsValid)
                {
                    if(gameNight.TotalPlayers+1 > gameNight.MaxPlayers) 
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
                        await _boardGameNightRepo.UpdateBoardGameNight(gameNight);
                        await _boardGameNightPlayerRepo.AddBoardGameNightPlayer(newPlayer);
                    }
               
                   
                   
                }


                //Total player +1 doen
                // Als al maxplayers is error geven

                //Speler toevoegen aan de list van gamenight
                //gameNight.BoardGameNightPlayer.Add(user);

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
               // var player1 = await _playerRepo.GetPlayerByMailAdress(user.Email);
                var gameNight = await _boardGameNightRepo.GetBoardGameNightByName(nameNight);
                var oldPlayer = await _boardGameNightPlayerRepo.GetBoardGameNightPlayersByName(user.Email);
                //if (player1 == null)
                //{
                //    throw new Exception("Player is null");

                //}

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
                       
                        // await _boardGameNightRepo.UpdateBoardGameNight(gameNight);
                        await _boardGameNightPlayerRepo.DestroyBoardGameNightPlayer(playerExists);
                    }

                    await _boardGameNightRepo.UpdateBoardGameNight(gameNight);

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
        public async Task<IActionResult> Create ()
        {
            var user = await _userManager.GetUserAsync(User);
            var player = await _playerRepo.GetPlayerByMailAdress(user.Email);

            var BoardGames = await _boardGameRepo.GetBoardGames();


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
                var player1 = await _playerRepo.GetPlayerByMailAdress(user.Email);

                boardGameNight.Host = user.Email;
                boardGameNight.TotalPlayers = 1;

                var newPlayer2 = new BoardGameNightPlayer()
                {
                    PlayerMailAddress = player1.MailAddress,
                    BoardGameNightNameNight = boardGameNight.NameNight,
                };

                boardGameNight.BoardGameNightPlayer.Add(newPlayer2);
                //boardGameNight.Boardgames = ViewBag.BoardGamesList;
                //if (ModelState.IsValid)
                //{
                    await _boardGameNightRepo.AddBoardGameNight(boardGameNight);
                    await _boardGameNightPlayerRepo.UpdateBoardGameNightPlayer(newPlayer2);
                //}

                TempData["SuccessMessage"] = "Successfully Created BoardGameNight: "+boardGameNight.NameNight;
                return RedirectToAction("Index");
              

            }
            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }


        }


    }
}
