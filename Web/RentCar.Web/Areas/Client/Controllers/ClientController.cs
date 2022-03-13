namespace RentCar.Web.Areas.Client.Controllers
{
    using RentCar.Common;
    using RentCar.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.Roles.Client)]
    [Area("Client")]
    public class ClientController : BaseController
    {
    }
}
