using RentCar.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Web.ViewModels.RentCarModels
{
    public class RentCarCreateInputModel : IMapTo<RentCar.Data.Models.RentCar>
    {
        public string CarId { get; set; }

        public double Price { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
