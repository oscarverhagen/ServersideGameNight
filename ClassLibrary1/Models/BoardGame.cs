using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.App.Models
{
    public class BoardGame
    {
        [Key]
        [Required]
        public string NameGame { get; set; }

        [Required]
        public string Genre { get; set; }
        [Required]
        public bool Mature { get; set; }
        [Required]
        public string Desciption { get; set; }

        [Required]
        public string KindOfGame { get; set; }
       
      
        public byte[] Photo { get; set; }


    }
}
