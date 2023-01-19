using Avans.GameNight.Core.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Avans.GameNight.Infrastructure.EntityFramework.Interfaces;

namespace Avans.GameNight.Infrastructure.EntityFramework.Repository
{
    public class BoardGameNightRepository : IBoardGameNightRepository
    {
        
        private DataContext.AppDbContext _appDbContext;
        public BoardGameNightRepository(DataContext.AppDbContext context)
        {

                _appDbContext = context;
        }

        public async Task AddBoardGameNight(BoardGameNight boardGameNight)
        {
            _appDbContext.BoardGameNight.Add(boardGameNight);
            await _appDbContext.SaveChangesAsync();
        }

        public Task DestroyBoardGameNight(BoardGameNight boardGameNight)
        {
          
                throw new NotImplementedException();
            
        }

        public async Task<BoardGameNight> GetBoardGameNightByName(string nameNight)
        {
            if (nameNight.Length < 1)
            {
                throw new ArgumentException("Error empty ", "nameNight");
            }
            else
            {

                return await _appDbContext.BoardGameNight
                .Include(bgnp => bgnp.BoardGameNightPlayer)
                .Include(bgnb2 => bgnb2.BoardGameNightBoardGame)
                .AsNoTracking().FirstOrDefaultAsync(x => x.NameNight == nameNight);

            }
        }

        public async Task<List<BoardGameNight>> GetBoardGameNights()
        {
            return await _appDbContext.BoardGameNight               
                .Include(bgnp => bgnp.BoardGameNightPlayer)
                .Include(bgnp2 => bgnp2.BoardGameNightBoardGame)
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<BoardGameNight>> GetBoardGameNightsByHost(string hostName)
        {
            if (hostName.Length < 1)
            {
                throw new ArgumentException("Error empty ", "nameNight");
            }
            else
            {
                return await _appDbContext.BoardGameNight
             .Include(bgnp => bgnp.BoardGameNightPlayer)
             .Include(bgnp1 => bgnp1.BoardGameNightBoardGame)
             .Where(bgnp2 => bgnp2.Host == hostName)
             .AsNoTracking().ToListAsync();
             
            }
        }

        public async Task UpdateBoardGameNight(BoardGameNight boardGameNight)
        {
            _appDbContext.Update(boardGameNight);
            await _appDbContext.SaveChangesAsync();
        }

        public Task UpdateBoardGameNightByBoardGameNight(string NameNight, BoardGameNight boardGameNight)
        {
            throw new NotImplementedException();
        }
    }
}
