using System.Collections.Generic;
using System.Linq;

namespace CarApp.Models
{
    class CrudCarRepository : ICrudCarRepository
    {
        private AppIdentityDbContext _context;
        public CrudCarRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public Car Find(int id)
        {
            return _context.Cars.Find(id);
        }
        public Car Delete(int id)
        {
            var product = _context.Cars.Remove(Find(id)).Entity;
            _context.SaveChanges();
            return product;
        }
        public Car Add(Car carData)
        {
            var entity = _context.Cars.Add(carData).Entity;
            _context.SaveChanges();
            return entity;
        }
        public Car Update(Car carData)
        {
            var entity = _context.Cars.Update(carData).Entity;
            _context.SaveChanges();
            return entity;
        }
        public IList<Car> FindAll()
        {
            return _context.Cars.ToList();
        }
    }
}
