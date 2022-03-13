using RentCar.Data.Models;
using RentCar.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCar.Web.ViewModels.UserModels
{
    public class UserDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Lastname { get; set; }

        public string EGN { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
