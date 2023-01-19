using Avans.GameNight.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Infrastructure.EntityFramework.Interfaces
{
    public interface IBoardGameNightBoardGameRepository
    {
        public Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames();

        public Task<IList<BoardGameNightBoardGame>> GetBoardGameNightBoardGamesByBoardGameName(string NameBoardGame);
        public Task AddBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame);
        public Task UpdateBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame);
        public Task UpdateBoardGameNightBoardGameByBoardGameNightBoardGame(string NameBoardGame, BoardGameNightBoardGame boardGameNightBoardGame);

        public Task DestroyBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame);
    }
}
