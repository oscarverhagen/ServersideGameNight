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

        public Task<IList<BoardGameNightBoardGame>> GetBoardGameByName(string nameGame);
        public Task AddGameNightBoardGame(BoardGameNightBoardGame gameNightBoardGame);
        public Task<List<BoardGameNight>> GetBoardGameNights();
        public Task DestroyGameNightBoardGame(BoardGameNightBoardGame gameNightBoardGame);
        public Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames();
    }
}
