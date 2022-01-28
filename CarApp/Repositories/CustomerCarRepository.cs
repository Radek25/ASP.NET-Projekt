using System.Collections.Generic;
using System.Linq;

namespace CarApp.Models
{
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
}
