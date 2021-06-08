using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepUKW.ViewModels
{
   public class LoginViewModel
   {
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        [Required(ErrorMessage = "Musisz wprowadzić login")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        [Required(ErrorMessage = "Musisz wprowadzić login")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Required(ErrorMessage = "Musisz wprowadzić oba hasła")]
        [Compare("Password", ErrorMessage = "Hasła muszą być jednakowe!")]
        public string ConfirmPassword { get; set; }
    }
}