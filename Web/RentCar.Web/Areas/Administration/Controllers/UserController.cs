using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentCar.Common;
using RentCar.Data.Models;
using RentCar.Web.Controllers;
using RentCar.Web.ViewModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentCar.Services.Mapping;

namespace RentCar.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.Roles.Administrator)]
    [Area("Administration")]
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Create() => this.View();

        public async Task<IActionResult> All()
        {
            IEnumerable<ApplicationUser> admins = await this.userManager.GetUsersInRoleAsync(GlobalConstants.Roles.Administrator);
            IEnumerable<ApplicationUser> clients = await this.userManager.GetUsersInRoleAsync(GlobalConstants.Roles.Client);

            var users = new List<UserViewModel>(admins.To<UserViewModel>());
            users.AddRange(clients.To<UserViewModel>());
            return this.View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(id);
            return this.View(user.To<UserDetailsViewModel>());
        }

        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(id);
            return this.View(user.To<UserEditInputModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditInputModel model)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(model.Id);
            user.Email = model.Email;
            user.Name = model.Name;
            user.UserName = model.Username;
            user.Surname = model.Surname;
            user.Name = model.Name;
            user.Lastname = model.Lastname;
            user.Surname = model.Surname;
            user.EGN = model.EGN;

            await this.userManager.UpdateAsync(user);
            return this.RedirectToAction(nameof(this.Details), new { model.Id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(id);
            return this.View(user.To<UserDetailsViewModel>());
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteComfirm(string id)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(id);
            await this.userManager.DeleteAsync(user);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
