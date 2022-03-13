namespace RentCar.Web.Areas.Administration.Controllers
{
    using RentCar.Common;
    using RentCar.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.Roles.Administrator)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
