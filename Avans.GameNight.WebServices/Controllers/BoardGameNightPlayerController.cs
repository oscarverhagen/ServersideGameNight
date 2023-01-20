
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
    }
}
