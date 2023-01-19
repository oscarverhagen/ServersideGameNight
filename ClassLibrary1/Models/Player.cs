using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.Core.Domain.Models
{
    public class Player
    {
        [Required]
        public string Name { get; set; }
        [Key]
        [Required]
        [EmailAddress]
        public string MailAddress { get; set; }

        [DataType(DataType.Date)]
        private DateTime _birthDate;
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
              
                if ((DateTime.Today.Year - value.Year) >= 18)
                {
                    Mature = true;
                    role = Role.HOST;
                    _birthDate = value;
                }
                else
                {
                    Mature = false;
                    role = Role.PLAYER;
                    _birthDate = value;
                }
               
            }
        }

        public Alert alert  { get; set; }
        
        public Gender gender { get; set; }
        [Required]
        public Role role { get; set; }
        public string Adress { get; set; }
        public bool Mature { get; set; }
        public string City { get; set; }
        public string DrinkPreference { get; set; }
        public string FoodPreference { get; set; }
        public int NotShow { get; set; }

        public IList<BoardGameNightPlayer> BoardGameNightPlayer { get; set; }
    }
}
