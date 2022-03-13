using RentCar.Web.ViewModels.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Services.Data.Interfaces
{
    public interface ICarService
    {
        Task Create(CarCreateInputModel model);

        Task Update(CarEditInputModel model, string id);

        IEnumerable<T> All<T>(CarFilter filter);

        T GetById<T>(string id);

        Task Delete(string id);
    }
}
