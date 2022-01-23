using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarApp.Models
{
    public interface ICarRepository
    {
        IQueryable<Car> Cars { get; }
    }
    public interface ICrudCarRepository
    {
        Car Find(int id);
        Car Delete(int id);
        Car Add(Car carData);
        Car Update(Car carData);
        IList<Car> FindAll();
    }
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
    public interface ICustomerCarRepository
    {
        IList<Car> FindAll();
        IList<Car> FindByBrandName(string brandName);
        IList<Car> FindByModelName(string modelName);
        Car FindById(int id);
    }
    class CustomerCarRepository : ICustomerCarRepository
    {
        private AppIdentityDbContext context;
        public CustomerCarRepository(AppIdentityDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        public IList<Car> FindAll()
        {
            return context.Cars.ToList();
        }
        public IList<Car> FindByBrandName(string brandName)
        {
            return (from p in context.Cars where p.Marka.Contains(brandName) select p).ToList();
        }
        public IList<Car> FindByModelName(string modelName)
        {
            return (from p in context.Cars where p.Model.Contains(modelName) select p).ToList();
        }
        public Car FindById(int id)
        {
            return context.Cars.Find(id);
        }
    }
    public class AppIdentityDbContext: IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
    }
    public class EFCarRepository : ICarRepository
    {
        private AppIdentityDbContext _applicationDbContext;
        public EFCarRepository(AppIdentityDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Car> Cars => _applicationDbContext.Cars;
    }
}
