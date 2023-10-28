using Avans.GameNight.Core.Domain.Models;

namespace Avans.GameNight.Core.Domain.Interfaces
{
    public interface IBoardGameRepository
    {
        public Task<List<BoardGame>> GetBoardGames();

        public Task<BoardGame> GetBoardGameByName(string nameGame);
        public Task AddBoardGame(BoardGame boardGame);
        public Task UpdateBoardGame(BoardGame boardGame);
        public Task UpdateBoardGameByBoardGame(string nameGame, BoardGame boardGame);

        public Task DestroyBoardGame(BoardGame boardGame);
    }
}
