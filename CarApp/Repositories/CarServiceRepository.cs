using CarApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Repositories
{
    public class CarServiceRepository : ICarRepository, ICarServiceRepository
    {
        private AppIdentityDbContext _context;
        public CarServiceRepository(AppIdentityDbContext context = null)
        {
            _context = context;
        }
        public IQueryable<Car> Cars => _context.Cars.Include("CarServices");
        public CarService Add(int carId)
        {
            var entity = _context.Cars.Where(c => c.id == carId).FirstOrDefault();
            CarService carService = new CarService() { Car = entity, DateOfService = DateTime.Now };
            _context.Add(carService);
            _context.SaveChanges();
            return carService;
        }
    }
}
