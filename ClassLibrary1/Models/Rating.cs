using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Avans.GameNight.App.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public string RaterId { get; set; }
        [Required]
        public string NameRater { get; set; }
        [Required]
        public bool mature { get; set; }
        [Required]
        public int RatingNight { get; set; }
        public string? FeedBack { get; set; }


    }
}
