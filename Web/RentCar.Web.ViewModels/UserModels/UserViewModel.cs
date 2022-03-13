using RentCar.Data.Models;
using RentCar.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Web.ViewModels.UserModels
{
    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }
    }
}
