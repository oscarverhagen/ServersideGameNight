using Avans.GameNight.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Avans.GameNight.Infrastructure.EntityFramework.Interfaces
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
