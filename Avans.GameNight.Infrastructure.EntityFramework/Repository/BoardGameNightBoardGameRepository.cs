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

        public async Task<BoardGameNightBoardGame> GETBGNByBoardGameName(string NameBoardGame)
        {
            if (NameBoardGame.Length < 0)
            {
                throw new ArgumentException("Error empty ", "NameBoardGame");
            }
            else
            {

                return await _appDbContext.BoardGameNightBoardGame
               .AsNoTracking().FirstOrDefaultAsync(x => x.BoardGameNameGame == NameBoardGame);

            }
        }

        public Task UpdateBoardGameNightBoardGame(BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoardGameNightBoardGameByBoardGameNightBoardGame(string NameBoardGame, BoardGameNightBoardGame boardGameNightBoardGame)
        {
            throw new NotImplementedException();
        }
    }
}
