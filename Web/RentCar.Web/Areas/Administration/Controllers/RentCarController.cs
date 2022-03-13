using Microsoft.AspNetCore.Mvc;
using RentCar.Services.Data.Interfaces;
using RentCar.Web.ViewModels.CarModels;
using RentCar.Web.ViewModels.RentCarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Web.Areas.Administration.Controllers
{
    public class RentCarAdminController : AdministrationController
    {
        private readonly IRentCarService rentCarService;

        public RentCarAdminController(IRentCarService rentCarService)
        {
            this.rentCarService = rentCarService;
        }

        public IActionResult Index()
         => this.View(this.rentCarService.All<RentCarViewModel>(new RentCarFilter()));
    }
}
