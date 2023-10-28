using Avans.GameNight.Core.Domain.Models;

namespace Avans.GameNight.Core.Domain.Interfaces
{
    public interface IBoardGameNightBoardGameRepository
    {
        public Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames();

        public Task<IList<BoardGameNightBoardGame>> GetBoardGameByName(string NameBoardGame);
        public Task AddBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame);
        public Task UpdateBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame);
        public Task UpdateBoardGameNightBoardGameByBoardGameName(string NameBoardGame, BoardGameNightBoardGame boardGameNightBoardGame);

        public Task DestroyBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame);
        Task<List<BoardGameNight>> GetBoardGameNights();
    }
}
