using Avans.GameNight.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Infrastructure.EntityFramework.Interfaces
{
    public interface IBoardGameNightPlayerRepository
    {
        public Task<List<BoardGameNightPlayer>> GetBoardGameNightPlayers();

        public Task<IList<BoardGameNightPlayer>> GetBoardGameNightPlayersByName(string NamePlayer);
        public Task AddBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);
        public Task UpdateBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);
        public Task UpdateBoardGameNightPlayerByBoardGameNightPlayer(string NamePlayer, BoardGameNightPlayer boardGameNightPlayer);

        public Task DestroyBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);

    }
}

