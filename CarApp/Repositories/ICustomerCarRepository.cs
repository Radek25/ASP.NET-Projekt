using System.Collections.Generic;

namespace CarApp.Models
{
    public interface ICustomerCarRepository
    {
        IList<Car> FindAll();
        IList<Car> FindByBrandName(string brandName);
        Car FindById(int id);
        IList<Car> FindByModelName(string modelName);
    }
}