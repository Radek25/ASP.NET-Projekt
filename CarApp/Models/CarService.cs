using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Models
{
    public class CarService
    {
        public int Id { get; set; }
        public DateTime DateOfService { get; set; }
        public Car Car { get; set; }
    }
}
