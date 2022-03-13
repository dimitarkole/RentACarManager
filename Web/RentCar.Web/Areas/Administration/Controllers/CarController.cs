using Microsoft.AspNetCore.Mvc;
using RentCar.Services.Data.Interfaces;
using RentCar.Web.ViewModels.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Web.Areas.Administration.Controllers
{
    public class CarController : AdministrationController
    {
        private readonly ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult Create() => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateInputModel car)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(car);
            }

            await this.carService.Create(car);
            return this.Redirect("/");
        }

        public IActionResult Edit(string id)
            => this.View(this.carService.GetById<CarEditInputModel>(id));

        [HttpPost]
        public async Task<IActionResult> Edit(CarEditInputModel car, string id)
        {
            await this.carService.Update(car, id);
            return this.Redirect("/");
        }

        public IActionResult Delete(string id)
        {
            var model = this.carService.GetById<CarDetailsModel>(id);
            return this.View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            await this.carService.Delete(id);
            return this.Redirect("/");
        }
    }
}
