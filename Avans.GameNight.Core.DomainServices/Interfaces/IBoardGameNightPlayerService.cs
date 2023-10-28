using Avans.GameNight.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans.GameNight.Core.DomainServices.Interfaces
{
    public interface IBoardGameNightPlayerService
    {
        Task<IList<BoardGameNightPlayer>> GetBoardGameNightPlayersByName(string NamePlayer);
        Task AddBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);
        Task DestroyBoardGameNightPlayer(BoardGameNightPlayer boardGameNightPlayer);

    }
}
