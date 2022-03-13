using RentCar.Data;
using RentCar.Services.Data.Interfaces;
using RentCar.Web.ViewModels.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Services.Mapping;
using RentCar.Data.Models;

namespace RentCar.Services.Data
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext context;

        public CarService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> All<T>(CarFilter filter)
        {
            IQueryable<Car> cars = this.context.Cars;
            /* if(filter.DateFrom!= default(DateTime))
             {
                 cars = cars.Where(c => c.RentCars.Any(rc => rc.DateFrom < filter.DateFrom));
             }*/

            return cars.To<T>().ToList();
        }

        public async Task Create(CarCreateInputModel model)
        {
            Car car = model.To<Car>();
            await this.context.Cars.AddAsync(car);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var car = this.context.Cars.Find(id);
            IQueryable<RentCar.Data.Models.RentCar> rentCarData = this.context.RentCars.Where(r => r.CarId == id);
            this.context.RentCars.RemoveRange(rentCarData);
            this.context.Cars.Remove(car);
            await this.context.SaveChangesAsync();
        }

        public T GetById<T>(string id)
            => this.context.Cars
                .Where(f => f.Id == id)
                .To<T>()
                .FirstOrDefault();

        public async Task Update(CarEditInputModel model, string id)
        {
            Car car = this.context.Cars.Find(id);
            car.Brand = model.Brand;
            car.Model = model.Model;
            car.Made = model.Made;
            car.CountPassagers = model.CountPassagers;
            car.Desctiption = model.Desctiption;
            car.Price = model.Price;
            car.ImageUrl = model.ImageUrl;

            this.context.Cars.Update(car);
            await this.context.SaveChangesAsync();
        }
    }
}
