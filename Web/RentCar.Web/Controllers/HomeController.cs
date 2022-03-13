namespace RentCar.Web.Controllers
{
    using System.Diagnostics;

    using RentCar.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using RentCar.Services.Data.Interfaces;
    using RentCar.Web.ViewModels.CarModels;

    public class HomeController : BaseController
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult Index()
            => this.View(this.carService.All<CarViewModel>(new CarFilter()));

        public IActionResult Details(string id)
          => this.View(this.carService.GetById<CarDetailsModel>(id));

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
