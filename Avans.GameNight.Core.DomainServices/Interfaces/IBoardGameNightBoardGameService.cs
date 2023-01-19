using Avans.GameNight.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Core.DomainServices.Interfaces
{
    public interface IBoardGameNightBoardGameService
    {
        public Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames();

        public Task<IList<BoardGameNightBoardGame>> GetBoardGameByName(string nameGame);
        public Task AddGetBoardGameNightBoardGame(BoardGameNightBoardGame boardGame);
        public Task UpdateGetBoardGameNightBoardGame(BoardGameNightBoardGame boardGame);
        public Task UpdateGetBoardGameNightBoardGameByGetBoardGameNightBoardGame(string nameGame, BoardGameNightBoardGame boardGame);

        public Task DestroyGetBoardGameNightBoardGame(BoardGameNightBoardGame boardGame);
    }
}
