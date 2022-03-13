using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentCar.Data.Models;
using RentCar.Services.Data.Interfaces;
using RentCar.Web.ViewModels.RentCarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Web.Areas.Client.Controllers
{
    public class RentCarController : ClientController
    {
        private readonly IRentCarService rentCarService;
        private readonly UserManager<ApplicationUser> userManager;

        public RentCarController(IRentCarService rentCarService,
            UserManager<ApplicationUser> userManager)
        {
            this.rentCarService = rentCarService;
            this.userManager = userManager;
        }

        public IActionResult Create(string carId)
        {
            var rentCar = new RentCarCreateInputModel();
            rentCar.CarId = carId;
            return View(rentCar);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentCarCreateInputModel car)
        {
            if (this.rentCarService.IsCarRented(car.CarId, car.DateFrom, car.DateTo))
            {
                ModelState.AddModelError(string.Empty, $"This car is not aveilable.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(car);
            }

            await this.rentCarService.Create(car, this.userManager.GetUserId(this.User));
            return this.Redirect("/");
        }
    }
}
