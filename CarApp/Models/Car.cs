using System.ComponentModel.DataAnnotations;

namespace CarApp.Models
{
    public class Car
    {
        [Required(ErrorMessage = "Padaj mark� samochodu!")]
        [MinLength(length:2, ErrorMessage = "Zbyt kt�rka nazwa marki samochodu!")]
        [MaxLength(length:20, ErrorMessage = "Zbyt d�uga nazwa marki samochodu!")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Padaj model samochodu!")]
        [MinLength(length: 1, ErrorMessage = "Zbyt kt�rka nazwa modelu samochodu!")]
        [MaxLength(length: 15, ErrorMessage = "Zbyt d�uga nazwa modelu samochodu!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Padaj rok produkcji samochodu!")]
        [RegularExpression("[2]{1}[0]{1}[0-2]{1}[0-9]{1}", ErrorMessage="Podano nieprawid�owy format daty!")]
        public string Rok { get; set; }
        [Required(ErrorMessage = "Uzupe�nij dane dotycz�ce silnika!!")]
        [RegularExpression("^^[a-zA-Z0-9-_. /s]+$", ErrorMessage = "Podano nieprawid�owe oznaczenie silnika!")]
        public string Silnik { get; set; }
        [Required(ErrorMessage = "Uzupe�nij informacje o paliwie!")]
        public string Paliwo { get; set; }
        [Required(ErrorMessage = "Uzupe�nij informacje o skrzyni bieg�w!!")]
        public string Skrzynia { get; set; }
        [Key]
        public int id { get; set; }
    }
}
