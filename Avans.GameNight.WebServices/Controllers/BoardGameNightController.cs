using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avans.GameNight.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameNightController : ControllerBase
    {

        private readonly IBoardGameNightRepository _boardGameNightRepo;
        private readonly IBoardGameNightPlayerRepository _boardGameNightPlayerRepo;
        private readonly IBoardGameNightBoardGameRepository _boardGameNightBoardGameRepo;
        private readonly IBoardGameRepository _boardGameRepo;
        private readonly IPlayerRepository _playerRepo;


        public BoardGameNightController(IBoardGameNightRepository boardGameNightRepo, IPlayerRepository playerRepo, IBoardGameRepository boardGameRepo, IBoardGameNightPlayerRepository boardGameNightPlayerRepo, IBoardGameNightBoardGameRepository BoardGameNightBoardGameRepository)
        {
            
            _boardGameNightRepo = boardGameNightRepo;
            _boardGameNightPlayerRepo = boardGameNightPlayerRepo;
            _playerRepo = playerRepo;
            _boardGameRepo = boardGameRepo;
            _boardGameNightBoardGameRepo = BoardGameNightBoardGameRepository;

        }

        // GET: api/<GameNightController>
        [HttpGet]
        public async Task<IEnumerable<BoardGameNightController>> Get()
        {
            var gameNights = await _boardGameNightRepo.GetBoardGameNights();
            return null;
        }
    }
}
