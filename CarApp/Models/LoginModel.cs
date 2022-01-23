using System;
using System.ComponentModel.DataAnnotations;

namespace CarApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Podaj login!")]
        public string Name{ get; set; }
        [Required(ErrorMessage = "Podaj has³o!")]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
