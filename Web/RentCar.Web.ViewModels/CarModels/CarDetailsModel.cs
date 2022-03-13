namespace RentCar.Web.ViewModels.CarModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentCar.Data.Models;
    using RentCar.Services.Mapping;

    public class CarDetailsModel : IMapFrom<Car>
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime Made { get; set; }

        public int CountPassagers { get; set; }

        public string Desctiption { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
