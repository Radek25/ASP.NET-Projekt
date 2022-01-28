using System.Linq;

namespace CarApp.Models
{
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
