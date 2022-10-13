using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.App.Models
{
    public class BoardGameNight
    {
        [Key]
        [Required]
        public string NameNight { get; set; }

        [Required]
        public string Host { get; set; }

        [Required]
        public int TotalPlayers { get; set; }
        [Required]
        public int MaxPlayers { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateTime { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public List <BoardGame>? Boardgames { get; set; }
      
        public string Food { get; set; }
        
        public string Drink { get; set; }
       
        public int Ratings { get; set; }


    }
}
