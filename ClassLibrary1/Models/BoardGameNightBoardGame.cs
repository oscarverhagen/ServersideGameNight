using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.App.Models
{
    public class BoardGameNightBoardGame
    {  [Key]
       public int IdBoardGame { get; set; }
        public string NameGame { get; set; }

        
        public string NameNight { get; set; }
   
        public BoardGame board { get; set; }

        public BoardGameNight BoardGameNight { get; set; }


    }
}
