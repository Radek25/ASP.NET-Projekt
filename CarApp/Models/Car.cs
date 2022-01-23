using System.ComponentModel.DataAnnotations;

namespace CarApp.Models
{
    public class Car
    {
        [Required(ErrorMessage = "Padaj markê samochodu!")]
        [MinLength(length:2, ErrorMessage = "Zbyt którka nazwa marki samochodu!")]
        [MaxLength(length:20, ErrorMessage = "Zbyt d³uga nazwa marki samochodu!")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Padaj model samochodu!")]
        [MinLength(length: 1, ErrorMessage = "Zbyt którka nazwa modelu samochodu!")]
        [MaxLength(length: 15, ErrorMessage = "Zbyt d³uga nazwa modelu samochodu!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Padaj rok produkcji samochodu!")]
        [RegularExpression("[2]{1}[0]{1}[0-2]{1}[0-9]{1}", ErrorMessage="Podano nieprawid³owy format daty!")]
        public string Rok { get; set; }
        [Required(ErrorMessage = "Uzupe³nij dane dotycz¹ce silnika!!")]
        [RegularExpression("^^[a-zA-Z0-9-_. /s]+$", ErrorMessage = "Podano nieprawid³owe oznaczenie silnika!")]
        public string Silnik { get; set; }
        [Required(ErrorMessage = "Uzupe³nij informacje o paliwie!")]
        public string Paliwo { get; set; }
        [Required(ErrorMessage = "Uzupe³nij informacje o skrzyni biegów!!")]
        public string Skrzynia { get; set; }
        [Key]
        public int id { get; set; }
    }
}
