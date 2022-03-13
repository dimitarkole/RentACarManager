using RentCar.Data;
using RentCar.Services.Data.Interfaces;
using RentCar.Web.ViewModels.RentCarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Services.Mapping;
using RentCar.Common;

namespace RentCar.Services.Data
{
    public class RentCarService : IRentCarService
    {
        private readonly ApplicationDbContext context;

        public RentCarService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> All<T>(RentCarFilter filter)
        {
            IQueryable<RentCar.Data.Models.RentCar> rentCars = this.context.RentCars;
            if(filter.Status != RentStatus.Null)
            {
                rentCars = rentCars.Where(rc => rc.RentStattus == filter.Status);
            }

            return rentCars.To<T>().ToList();
        }

        public IEnumerable<T> AllOwned<T>(string userId)
            => this.context.RentCars
                .Where(rc => rc.UserId == userId)
                .To<T>()
                .ToList();

        public async Task Create(RentCarCreateInputModel model, string userId)
        {
            var rentCar = model.To<RentCar.Data.Models.RentCar>();
            await this.context.RentCars.AddAsync(rentCar);
            await this.context.SaveChangesAsync();
        }

        public bool IsCarRented(string carId, DateTime from, DateTime to)
            => this.context.RentCars.Any(rc => (from.CompareTo(rc.DateFrom) > 0 && to.CompareTo(rc.DateTo) > 0)
                || (from.CompareTo(rc.DateFrom) < 0 && to.CompareTo(rc.DateTo) < 0)
                || ( from.CompareTo(rc.DateFrom) < 0 && to.CompareTo(rc.DateTo) > 0)
                || (from.CompareTo(rc.DateFrom) > 0 && to.CompareTo(rc.DateTo) < 0));
    }
}
