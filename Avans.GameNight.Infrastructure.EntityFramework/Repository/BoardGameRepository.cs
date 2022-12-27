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
    public class BoardGameRepository : IBoardGameRepository
    {
        
        private DataContext.AppDbContext _appDbContext;
        public BoardGameRepository(DataContext.AppDbContext context)
        {

                _appDbContext = context;
        }

        public async Task AddBoardGame(BoardGame boardGame)
        {
            _appDbContext.BoardGame.Add(boardGame);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DestroyBoardGame(BoardGame boardGame)
        {
            _appDbContext.Remove(boardGame);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<BoardGame> GetBoardGameByName(string nameGame)
        {
            if (nameGame.Length <= 0)
            {
                throw new ArgumentException("Length should be bigger then 0", "nameGame");
            }
            else
            {
                return await _appDbContext.BoardGame.FirstOrDefaultAsync(p => p.NameGame == nameGame);
            }
        }

        public async Task<List<BoardGame>> GetBoardGames()
        {
            return await _appDbContext.BoardGame.ToListAsync();
        }

        public Task UpdateBoardGame(BoardGame boardGame)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoardGameByBoardGame(string nameGame, BoardGame boardGame)
        {
            throw new NotImplementedException();
        }
    }
}
