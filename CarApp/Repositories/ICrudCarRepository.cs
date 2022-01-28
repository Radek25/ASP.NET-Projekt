using System.Collections.Generic;

namespace CarApp.Models
{
    public interface ICrudCarRepository
    {
        Car Add(Car carData);
        Car Delete(int id);
        Car Find(int id);
        IList<Car> FindAll();
        Car Update(Car carData);
    }
}