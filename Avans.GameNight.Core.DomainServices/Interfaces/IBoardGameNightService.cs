using Avans.GameNight.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Core.DomainServices.Interfaces
{

    public interface IBoardGameNightService : IBoardGameNightBoardGameService, IBoardGameNightPlayerService
    {
        public Task<List<BoardGameNight>> GetBoardGameNights();
        public Task<BoardGameNight> GetBoardGameNightByName(string NameNight);
        public Task<IList<BoardGameNight>> GetBoardGameNightsByHost(string hostName);

        public Task AddBoardGameNight(BoardGameNight boardGameNight);
        public Task UpdateBoardGameNightByBoardGameNight(BoardGameNight boardGameNight);
        public Task DestroyBoardGameNight(BoardGameNight boardGameNight);


    }
}
