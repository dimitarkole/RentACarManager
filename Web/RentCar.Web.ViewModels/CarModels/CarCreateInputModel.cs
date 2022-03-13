using RentCar.Data.Models;
using RentCar.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentCar.Web.ViewModels.CarModels
{
    public class CarCreateInputModel : IMapTo<Car>
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public DateTime Made { get; set; }

        [Required]
        public int CountPassagers { get; set; }

        [Required]
        public string Desctiption { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
