
using Avans.GameNight.Core.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Avans.GameNight.Core.Domain.Interfaces;

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

        public async Task<Player> GetPlayerByMailAdress(string mail)
        {
           
            if (mail.Length < 1)
            {
                throw new ArgumentException("Error empty ", "mailAdress");
            }
            else
            {

                return await _appDbContext.Player.AsNoTracking().FirstOrDefaultAsync(x => x.MailAddress == mail);
              
            }
        }
        //return await _appDbContext.Player.FirstAsync(x => x.MailAdress == player.MailAdress);
        //    return await _appDbContext.Player.FirstOrDefaultAsync(x => x.MailAdress.Equals(mail));

        public async Task<List<Player>> GetPlayers()
        {
            return await _appDbContext.Player.AsNoTracking().ToListAsync();
        }

        public async Task UpdatePlayer(Player player)
        {
            _appDbContext.Update(player);
            await _appDbContext.SaveChangesAsync();
        }

        public Task UpdatePlayerByPlayer(int id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
