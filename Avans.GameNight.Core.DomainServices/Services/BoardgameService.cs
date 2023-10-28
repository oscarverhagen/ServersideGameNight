using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Core.DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans.GameNight.Core.Domain.Interfaces;

namespace Avans.GameNight.Core.DomainServices.Services
{
    internal class BoardgameService : IBoardgameService
    {
       private readonly IBoardGameRepository _boardGameRepository;

        public BoardgameService(IBoardGameRepository boardGameRepository)
        {
            _boardGameRepository = boardGameRepository;
        }

        public async Task AddBoardGame(BoardGame boardGame)
        {
            await _boardGameRepository.AddBoardGame(boardGame);
        }

        public async Task DestroyBoardGame(BoardGame boardGame)
        {
            await _boardGameRepository.DestroyBoardGame(boardGame);
        }

        public async Task<BoardGame> GetBoardGameByName(string nameGame)
        {
            return await _boardGameRepository.GetBoardGameByName(nameGame);
        }

        public async Task<List<BoardGame>> GetBoardGames()
        {
            return await _boardGameRepository.GetBoardGames();
        }

        public async Task UpdateBoardGame(BoardGame boardGame)
        {
            await _boardGameRepository.UpdateBoardGame(boardGame);
        }

        public async Task UpdateBoardGameByBoardGame(string nameGame, BoardGame boardGame)
        {
            await _boardGameRepository.UpdateBoardGameByBoardGame(nameGame, boardGame);
        }
    }
}
