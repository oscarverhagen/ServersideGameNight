using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.App.Models
{
    public class BoardGameNightPlayer
    {

        [Key]
        public int IdPlayer { get; set; }
        public string GameName { get; set; }
            public Player Player { get; set; }

            public string NameNight { get; set; }
            public BoardGameNight BoardGameNight { get; set; }
        


    }
}
