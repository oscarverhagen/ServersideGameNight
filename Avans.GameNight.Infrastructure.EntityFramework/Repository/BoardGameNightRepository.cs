using Avans.GameNight.Core.DomainServices.Interfaces;
using Avans.GameNight.App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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

                return await _appDbContext.BoardGameNight.FirstOrDefaultAsync(x => x.NameNight == nameNight);

            }
        }

        public async Task<List<BoardGameNight>> GetBoardGameNights()
        {
            return await _appDbContext.BoardGameNight.ToListAsync();
        }

        public Task UpdateBoardGameNight(BoardGameNight boardGameNight)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoardGameNightByBoardGameNight(string NameNight, BoardGameNight boardGameNight)
        {
            throw new NotImplementedException();
        }
    }
}
