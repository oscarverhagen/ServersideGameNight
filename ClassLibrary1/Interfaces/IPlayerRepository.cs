using Avans.GameNight.Core.Domain.Models;

namespace Avans.GameNight.Core.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<List<Player>> GetPlayers();

        public Task<Player> GetPlayerByMailAdress(string mail);
        public Task AddPlayer(Player player);
        public Task UpdatePlayer(Player player);
        public Task UpdatePlayerByPlayer(int id, Player player);

        public Task DestroyPlayer(Player player);
    }
}
