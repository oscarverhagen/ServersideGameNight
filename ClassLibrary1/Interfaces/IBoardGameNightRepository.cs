using Avans.GameNight.Core.Domain.Models;

namespace Avans.GameNight.Core.Domain.Interfaces
{
    public interface IBoardGameNightRepository
    {
        public Task<List<BoardGameNight>> GetBoardGameNights();

        public Task<List<BoardGameNight>> GetBoardGameNightsByHost(string hostName);

        public Task<BoardGameNight> GetBoardGameNightByName(string NameNight);
        public Task AddBoardGameNight(BoardGameNight boardGameNight);
        public Task UpdateBoardGameNight(BoardGameNight boardGameNight);
        public Task UpdateBoardGameNightByBoardGameNight(string NameNight, BoardGameNight boardGameNight);

        public Task DestroyBoardGameNight(BoardGameNight boardGameNight);

    }
}
