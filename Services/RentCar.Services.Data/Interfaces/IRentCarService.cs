using RentCar.Web.ViewModels.RentCarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Services.Data.Interfaces
{
    public interface IRentCarService
    {
        Task Create(RentCarCreateInputModel model, string userId);

        IEnumerable<T> All<T>(RentCarFilter filter);

        bool IsCarRented(string carId, DateTime from, DateTime to);

        IEnumerable<T> AllOwned<T>(string userId);
    }
}
