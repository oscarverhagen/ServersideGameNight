using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Infrastructure.EntityFramework.Repository
{
    public class BoardGameNightBoardGameRepository : IBoardGameNightBoardGameRepository
    {
        public Task AddBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }

        public Task DestroyBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames()
        {
            throw new NotImplementedException();
        }

        public Task<IList<BoardGameNightBoardGame>> GetBoardGameNightBoardGamesByBoardGameName(string NameBoardGame)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoardGameNightBoardGameByBoardGameNightBoardGame(string NameBoardGame, BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }
    }
}
