namespace RentCar.Web.ViewModels.CarModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentCar.Data.Models;
    using RentCar.Services.Mapping;

    public class CarViewModel : IMapFrom<Car>
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
