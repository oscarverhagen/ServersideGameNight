using Avans.GameNight.Core.Domain.Models;

namespace Avans.GameNight.Core.Domain.Interfaces
{
    public interface IBoardGameNightPlayerRepository
    {
        public Task<List<BoardGameNightPlayer>> GetBoardGameNightPlayers();

        public Task<IList<BoardGameNightPlayer>> GetBoardGameNightPlayersByName(string NamePlayer);
        public Task AddBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);
        public Task UpdateBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);
        public Task UpdateBoardGameNightPlayerByBoardGameNightPlayer(string NamePlayer, BoardGameNightPlayer boardGameNightPlayer);

        public Task DestroyBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);

    }
}

