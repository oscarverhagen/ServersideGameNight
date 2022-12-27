using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Avans.GameNight.App.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }


        [DataType(DataType.Date)]
        public DateTime _birthDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                //if (value > DateTime.Today)
                //{
                //    throw new ArgumentException("Birthdate of a user cannot be in the future", "BirthDate");
                //}
                //if ((DateTime.Today.Year - value.Year) < 16)
                //{
                //    throw new ArgumentException("Minimal age is 16", "BirthDate");
                //}
              
                _birthDate = value;
            }
        }


    }
}
