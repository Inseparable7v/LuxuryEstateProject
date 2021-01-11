namespace LuxuryEstateProject.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LuxuryEstateProject.Common;
    using LuxuryEstateProject.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class AdminSeeder : ISeeder
    {
        private static string adminUserName = "admin@localhost";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoleAsync(userManager, GlobalConstants.AdministratorRoleName);
        }

        private static async Task SeedRoleAsync(UserManager<ApplicationUser> userManager, string roleName)
        {
            if (userManager.FindByNameAsync(
                        adminUserName).Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = adminUserName;
                user.Email = adminUserName;

                var result = userManager.CreateAsync(
                user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName).Wait();
                }
            }
        }
    }
}
