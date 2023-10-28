using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Core.Domain.Interfaces;
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

        public async Task UpdateBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            _appDbContext.Update(boardGameNightBoardGame);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DestroyBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            _appDbContext.Remove(boardGameNightBoardGame);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<List<BoardGameNight>> GetBoardGameNights()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BoardGameNightBoardGame>> GetBoardGameNightBoardGames()
        {
            return await _appDbContext.BoardGameNightBoardGame.AsNoTracking().ToListAsync();
        }

        public async Task<IList<BoardGameNightBoardGame>> GetBoardGameByName(string NameBoardGame)
        {
            if (NameBoardGame.Length < 1)
            {
                throw new ArgumentException("Error empty ", "NameBoardGame");
            }
            else
            {
                return await _appDbContext.BoardGameNightBoardGame
                    .AsNoTracking()
                    .Where(x => x.BoardGameNameGame == NameBoardGame)
                    .ToListAsync();
            }
        }

        public async Task UpdateBoardGameNightBoardGameByBoardGameName(string NameBoardGame, BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }
    }
}
