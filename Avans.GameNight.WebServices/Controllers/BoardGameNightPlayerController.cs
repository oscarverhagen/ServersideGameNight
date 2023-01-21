
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using Avans.GameNight.Core.Domain.Models;


namespace Avans.GameNight.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameNightPlayerController : ControllerBase
    {
        private readonly IBoardGameNightRepository _boardGameNightRepo;
        private readonly IBoardGameNightPlayerRepository _boardGameNightPlayerRepo;
        private readonly IBoardGameNightBoardGameRepository _boardGameNightBoardGameRepo;
        private readonly IBoardGameRepository _boardGameRepo;
        private readonly IPlayerRepository _playerRepo;


        public BoardGameNightPlayerController(IBoardGameNightRepository boardGameNightRepo, IPlayerRepository playerRepo, IBoardGameRepository boardGameRepo, IBoardGameNightPlayerRepository boardGameNightPlayerRepo, IBoardGameNightBoardGameRepository BoardGameNightBoardGameRepository)
        {

            _boardGameNightRepo = boardGameNightRepo;
            _boardGameNightPlayerRepo = boardGameNightPlayerRepo;
            _playerRepo = playerRepo;
            _boardGameRepo = boardGameRepo;
            _boardGameNightBoardGameRepo = BoardGameNightBoardGameRepository;

        }

        // POST api/<GameNightPlayerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BoardGameNightPlayer gameNightPlayer)
        {
            try
            {
                var gamenight = await _boardGameNightRepo.GetBoardGameNightByName(gameNightPlayer.BoardGameNightNameNight);

               

                var player = await _playerRepo.GetPlayerByMailAdress(gameNightPlayer.PlayerMailAddress);
                if (player == null)
                {
                    return NotFound("Player not found");
                }
                if (player.MailAddress == gamenight.Host)
                {
                    return BadRequest("Cannot join own gamenight");
                }
                await _boardGameNightPlayerRepo.AddBoardGameNightPlayer(gameNightPlayer);
                return Ok("Succesfully joined the gamenight");
                //return RedirectToAction(routeName);
            }
            catch (Exception ex)
            {
                //TempData["ErrorMessage"] = ex.Message;
                return BadRequest(ex.Message);

            }

        }

    }
}
