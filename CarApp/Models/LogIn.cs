using System;
using System.ComponentModel.DataAnnotations;

namespace CarApp.Models
{
    public class LogIn
    {
        [Required(ErrorMessage = "Podaj login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Podaj has³o!")]
        public string Password { get; set; }
    }
}
