using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RentCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentCar.Common.GlobalConstants;

namespace RentCar.Data.Seeding
{
    public class UserSeeder : ISeeder
    {
        public class UserObj
        {
            public string Username { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Role { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Lastname { get; set; }
            public string EGN { get; set; }
        }

        public List<UserObj> Users = new List<UserObj>()
        {
            new UserObj() {
                Username = "rootadmin",
                Email = "rootadmin@abv.bg",
                Name = "Admin",
                Surname = "Admin",
                Lastname = "Admin",
                EGN = "0242352562",
                Password = "rootpass",
                Role = Roles.Administrator
            },
            new UserObj() {
                Username = "rootuser",
                Email = "rootuser@abv.bg",
                Name = "User",
                Surname = "User",
                Lastname = "User",
                EGN = "0242452562",
                Password = "rootpass",
                Role = Roles.Client,
            },
        };
            
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            foreach (var user in this.Users)
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var userFromDb = await userManager.FindByNameAsync(user.Username);

                if (userFromDb == null)
                {
                    var userAdd = new ApplicationUser
                    {
                        UserName = user.Username,
                        Name = user.Name,
                        Surname = user.Surname,
                        EGN = user.EGN,
                        Lastname = user.Lastname,
                        Email = user.Email,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(userAdd, user.Password);
                    await userManager.AddToRoleAsync(userAdd, user.Role);
                }
            }
        }
    }
}
