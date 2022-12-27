using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        [Required]
        [NotMapped]
        public IFormFile Picture;


        public byte[] PictureB { get; set; }

    
        public string PictureFormat { get; set; }

        public IList<BoardGameNightBoardGame> BoardGameNightBoardGame { get; set; }

    }
}
