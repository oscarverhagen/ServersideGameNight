using Avans.GameNight.App.Models;
using Microsoft.AspNetCore.Mvc;
using Avans.GameNight.Core.DomainServices.Interfaces;
using Microsoft.AspNetCore.Identity;


namespace Avans.GameNight.App.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBoardGameRepository _boardGameRepo;
        private readonly IPlayerRepository _playerRepo;

        public BoardGameController(UserManager<IdentityUser> userManager, IBoardGameRepository boardGameRepo, IPlayerRepository playerRepo)
        {
            _userManager = userManager;
            _boardGameRepo = boardGameRepo;
            _playerRepo = playerRepo;

        }

        public ActionResult AccesDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var boardGames = await _boardGameRepo.GetBoardGames();
            
            


            return View(boardGames); 
        }

     

        //public async Task<IActionResult> Edit()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var player = await _boardGameRepo.GetPlayerByMailAdress(user.Email);
        //    return View(player);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(Player playerTemp)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        await _playerRepo.UpdatePlayer(playerTemp);
        //    }
        //    return RedirectToAction("Profile", new { MailAdress = playerTemp.MailAdress });

        //}



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var player = await _playerRepo.GetPlayerByMailAdress(user.Email);

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
        public async Task<IActionResult> Create(BoardGame boardGame)
        {
            try
            {
                var image = Request.Form.Files[0];

                var temp = new BoardGame
                {
                    NameGame = boardGame.NameGame,
                    Genre = boardGame.Genre,
                    Desciption = boardGame.Desciption,  
                    Mature = boardGame.Mature,  
                    KindOfGame = boardGame.KindOfGame,
                    PictureFormat = image.ContentType,

              
                };
               
                var memoryStream = new MemoryStream();
                image.CopyTo(memoryStream);
                temp.PictureB = memoryStream.ToArray();

                //if (ModelState.IsValid)
                //{
                   

                    await _boardGameRepo.AddBoardGame(temp);
                //}

                return RedirectToAction("Index");


            }
            catch (ArgumentException)
            {
                return this.NotFound("The user is not found.");
            }


        }

        // POST: PatientController/Delete/5
        [HttpPost]
       
        public async Task<IActionResult> Delete(string name)
        {
            //GetPatientById can throw an error about id not higher than 0
            try
            {
                var game = await _boardGameRepo.GetBoardGameByName(name);

                if (game == null)
                {
                    return NotFound("The BoardGame requested to delete has not been found.");
                }
                await _boardGameRepo.DestroyBoardGame(game);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

