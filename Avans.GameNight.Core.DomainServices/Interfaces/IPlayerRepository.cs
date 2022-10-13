using Avans.GameNight.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Avans.BoardGameNight.Core.DomainServices.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<List<Player>> GetPlayers();

        public Task<Player> GetPlayerById(int id);
        public Task AddPlayer(Player player);
        public Task UpdatePlayer(Player player);
        public Task UpdatePlayerByPlayer(int id, Player player);

        public Task DestroyPlayer(Player player);
    }
}
