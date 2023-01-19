using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.Core.Domain.Models
{
    public class BoardGameNightPlayer
    {

            public string PlayerMailAddress { get; set; }
            public Player ?Player { get; set; }

            public string BoardGameNightNameNight { get; set; }
            public BoardGameNight ?BoardGameNight { get; set; }
        


    }
}
