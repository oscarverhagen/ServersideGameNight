using Microsoft.AspNetCore.Identity;
using Avans.GameNight.Core.Domain.Interfaces;
using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Core.DomainServices.Interfaces;


namespace Avans.GameNight.Core.DomainServices.Services
{
    public class BoardGameNightService : IBoardGameNightBoardGameService, IBoardGameNightService
    {
        private readonly IBoardGameNightRepository _boardGameNightRepo;
        private readonly IBoardGameNightPlayerRepository _boardGameNightPlayerRepo;
        private readonly IBoardGameNightBoardGameRepository _boardGameNightBoardGameRepo;
        private readonly IBoardGameRepository _boardGameRepo;
        private readonly IPlayerRepository _playerRepo;
        private readonly UserManager<IdentityUser> _userManager;

        public BoardGameNightService(
            UserManager<IdentityUser> userManager,
            IBoardGameNightRepository boardGameNightRepo,
            IPlayerRepository playerRepo,
            IBoardGameRepository boardGameRepo,
            IBoardGameNightPlayerRepository boardGameNightPlayerRepo,
            IBoardGameNightBoardGameRepository boardGameNightBoardGameRepo)
        {
            _userManager = userManager;
            _boardGameNightRepo = boardGameNightRepo;
            _boardGameNightPlayerRepo = boardGameNightPlayerRepo;
            _playerRepo = playerRepo;
            _boardGameRepo = boardGameRepo;
            _boardGameNightBoardGameRepo = boardGameNightBoardGameRepo;
        }

        public async Task<List<BoardGameNight>> GetBoardGameNights()
        {


            return await this._boardGameNightRepo.GetBoardGameNights() as List<BoardGameNight>;

        }

        public async Task<BoardGameNight> GetBoardGameNightByName(string NameNight)
        {
            return await this._boardGameNightRepo.GetBoardGameNightByName(NameNight);
        }

        public async Task<IList<BoardGameNight>> GetBoardGameNightsByHost(string hostName)
        {
            return await this._boardGameNightRepo.GetBoardGameNightsByHost(hostName);
        }

        public async Task AddBoardGameNight(BoardGameNight boardGameNight)
        {
            await this._boardGameNightRepo.AddBoardGameNight(boardGameNight);
        }

        public async Task UpdateBoardGameNightByBoardGameNight(BoardGameNight boardGameNight)
        {
            throw new NotImplementedException();
        }

        public Task DestroyBoardGameNight(BoardGameNight boardGameNight)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BoardGameNightBoardGame>> GetBoardGameByName(string nameGame)
        {
            return await _boardGameNightBoardGameRepo.GetBoardGameByName(nameGame);
        }

        public async Task AddGameNightBoardGame(BoardGameNightBoardGame gameNightBoardGame)
        {
            await _boardGameNightBoardGameRepo.AddBoardGameNightBoardGame(gameNightBoardGame);
        }

        public  Task DestroyGameNightBoardGame(BoardGameNightBoardGame gameNightBoardGame)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames()
        {
            return await _boardGameNightBoardGameRepo.GetBoardGameNightBoardGames();
        }

        public async Task<IList<BoardGameNightPlayer>> GetBoardGameNightPlayersByName(string NamePlayer)
        {
            return await _boardGameNightPlayerRepo.GetBoardGameNightPlayersByName(NamePlayer);
        }

        public async Task AddBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer)
        {
            await _boardGameNightPlayerRepo.AddBoardGameNightPlayer(boardGameNightPlayer);
        }

        public Task DestroyBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
