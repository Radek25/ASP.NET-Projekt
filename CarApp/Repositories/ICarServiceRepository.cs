using CarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Repositories
{
    public interface  ICarServiceRepository
    {
        public CarService Add(int carId);
    }
}
