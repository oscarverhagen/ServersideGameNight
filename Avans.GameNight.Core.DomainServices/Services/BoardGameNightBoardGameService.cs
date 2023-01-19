using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Core.DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Core.DomainServices.Services
{
    public class BoardGameNightBoardGameService : IBoardGameNightBoardGameService
    {
        public Task AddGetBoardGameNightBoardGame(BoardGameNightBoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        public Task DestroyGetBoardGameNightBoardGame(BoardGameNightBoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BoardGameNightBoardGame>> GetBoardGameByName(string nameGame)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames()
        {
            throw new NotImplementedException();
        }

        public Task UpdateGetBoardGameNightBoardGame(BoardGameNightBoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGetBoardGameNightBoardGameByGetBoardGameNightBoardGame(string nameGame, BoardGameNightBoardGame boardGame)
        {
            throw new NotImplementedException();
        }
    }
}
