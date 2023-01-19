using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Infrastructure.EntityFramework.Repository
{
    public class BoardGameNightPlayerRepository : IBoardGameNightPlayerRepository
    {
        private DataContext.AppDbContext _appDbContext;
        public BoardGameNightPlayerRepository(DataContext.AppDbContext context)
        {

            _appDbContext = context;
        }
        public async Task AddBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer)
        {
            _appDbContext.BoardGameNightPlayer.Add(boardGameNightPlayer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DestroyBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer)
        {
            _appDbContext.Remove(boardGameNightPlayer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IList<BoardGameNightPlayer>> GetBoardGameNightPlayersByName(string NamePlayer)
        {
            if (NamePlayer.Length < 1)
            {
                throw new ArgumentException("Error empty ", "nameNight");
            }
            else
            {

                return await _appDbContext.BoardGameNightPlayer
                    //.Include(bgnp => bgnp.PlayerMailAddress)
                    .AsNoTracking().Where(x=>x.PlayerMailAddress == NamePlayer).ToListAsync();

            }
        }

        public Task<List<BoardGameNightPlayer>> GetBoardGameNightPlayers()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer)
        {
            _appDbContext.Update(boardGameNightPlayer);
            await _appDbContext.SaveChangesAsync();
        }

        public Task UpdateBoardGameNightPlayerByBoardGameNightPlayer(string NamePlayer, BoardGameNightPlayer boardGameNightPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
