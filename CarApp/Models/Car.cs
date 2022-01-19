using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        private ApplicationDbContext _context;
        public CrudCarRepository(ApplicationDbContext context)
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
        private ApplicationDbContext context;
        public CustomerCarRepository(ApplicationDbContext applicationDbContext)
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
        //public ICollection<User> Users { get; set; }
        public User User { get; set; }
        public int Userid { get; set; } 
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
    }
    public class EFCarRepository : ICarRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public EFCarRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IQueryable<Car> Cars => _applicationDbContext.Cars;
    }
}
