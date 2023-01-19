using Avans.GameNight.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Avans.GameNight.Infrastructure.EntityFramework.Interfaces
{
    public interface IBoardGameRepository
    {
        public Task<List<BoardGame>> GetBoardGames();

        public Task<BoardGame> GetBoardGameByName(string nameGame);
        public Task AddBoardGame(BoardGame boardGame);
        public Task UpdateBoardGame(BoardGame boardGame);
        public Task UpdateBoardGameByBoardGame(string nameGame, BoardGame boardGame);

        public Task DestroyBoardGame(BoardGame boardGame);
    }
}
