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
    public class BoardGameNightBoardGameRepository : IBoardGameNightBoardGameRepository
    {
        private DataContext.AppDbContext _appDbContext;
        public BoardGameNightBoardGameRepository(DataContext.AppDbContext context)
        {

            _appDbContext = context;
        }
        public async Task AddBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            _appDbContext.BoardGameNightBoardGame.Add(boardGameNightBoardGame);
            await _appDbContext.SaveChangesAsync();
        }

        public Task DestroyBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BoardGameNightBoardGame>> GETBGNByBoardGameName(string NameBoardGame)
        {
            if (NameBoardGame.Length < 1)
            {
                throw new ArgumentException("Error empty ", "NameBoardGame");
            }
            else
            {
                return await _appDbContext.BoardGameNightBoardGame
                                  //.Include(bgnp => bgnp.PlayerMailAddress)
                                  .AsNoTracking().Where(x => x.BoardGameNameGame == NameBoardGame).ToListAsync();
              
            }
        }

        public async Task UpdateBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            _appDbContext.Update(boardGameNightBoardGame);
            await _appDbContext.SaveChangesAsync();
        }

        public Task UpdateBoardGameNightBoardGameByBoardGameNightBoardGame(string NameBoardGame, BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }
    }
}
