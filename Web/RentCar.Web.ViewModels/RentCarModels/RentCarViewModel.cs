using RentCar.Common;
using RentCar.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Web.ViewModels.RentCarModels
{
    public class RentCarViewModel : IMapFrom<RentCar.Data.Models.RentCar>
    {
        public string Id { get; set; }
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string CarBrand { get; set; }

        public RentStatus RentStattus { get; set; }

        public string UserId { get; set; }

        public string UserUsername { get; set; }
    }
}
