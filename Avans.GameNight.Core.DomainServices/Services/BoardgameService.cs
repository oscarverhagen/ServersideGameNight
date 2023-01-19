using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Core.DomainServices.Interfaces;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Core.DomainServices.Services
{
    internal class BoardgameService : IBoardgameService
    {
        private IBoardGameRepository boardGameRepository;
        public BoardgameService(IBoardGameRepository boardgameRepository)
        {
                this.boardGameRepository = boardgameRepository;
        }
        public Task AddBoardGame(BoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        public Task DestroyBoardGame(BoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        public Task<BoardGame> GetBoardGameByName(string nameGame)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoardGame>> GetBoardGames()
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoardGame(BoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoardGameByBoardGame(string nameGame, BoardGame boardGame)
        {
            throw new NotImplementedException();
        }
    }
}
