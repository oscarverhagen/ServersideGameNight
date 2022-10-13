using Avans.BoardGameNight.Core.DomainServices.Interfaces;
using Avans.GameNight.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Infrastructure.EntityFramework.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private DataContext.AppDbContext _appDbContext;
        public PlayerRepository(DataContext.AppDbContext context)
        {
                _appDbContext = context;
        }
        public async Task AddPlayer(Player player)
        {
            _appDbContext.Player.Add(player);
            await _appDbContext.SaveChangesAsync();
            
        }

        public Task DestroyPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetPlayerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlayerByPlayer(int id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
