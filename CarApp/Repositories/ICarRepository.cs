using System.Linq;

namespace CarApp.Models
{
    public interface ICarRepository
    {
        IQueryable<Car> Cars { get; }
    }
}