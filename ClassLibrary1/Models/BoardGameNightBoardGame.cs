using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.Core.Domain.Models
{
    public class BoardGameNightBoardGame
    { 
       public string BoardGameNameGame { get; set; }
        public BoardGame ?BoardGame { get; set; }


        public string BoardGameNightNameNight { get; set; }
        public BoardGameNight? BoardGameNight { get; set; }


    }
}
