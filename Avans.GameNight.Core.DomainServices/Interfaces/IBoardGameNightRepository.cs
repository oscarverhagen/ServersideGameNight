using Avans.GameNight.App.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace Avans.GameNight.Core.DomainServices.Interfaces
{
    public interface IBoardGameNightRepository
    {
        public Task<List<BoardGameNight>> GetBoardGameNights();

        public Task<BoardGameNight> GetBoardGameNightByName(string NameNight);
        public Task AddBoardGameNight(BoardGameNight boardGameNight);
        public Task UpdateBoardGameNight(BoardGameNight boardGameNight);
        public Task UpdateBoardGameNightByBoardGameNight(string NameNight, BoardGameNight boardGameNight);

        public Task DestroyBoardGameNight(BoardGameNight boardGameNight);

    }
}
