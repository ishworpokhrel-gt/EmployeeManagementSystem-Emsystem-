
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Data
{
    public static class DbSeeder
    {
        public static async Task RolesSeedingOnDb(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Accountant.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Employe.ToString()));

            var user = new ApplicationUser
            {
                UserName = "Admin@gmail.com",
                Name = "Admin",
                Email = "Admin@gmail.com",
                city="kathmandu",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,

            };

            var user1 = new ApplicationUser
            {
                UserName = "Accountant@gmail.com",
                Name = "Accountant",
                Email = "Accountant@gmail.com",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
            };
            

            var userindb = await userManager.FindByEmailAsync(user.Email);
            if (userindb == null)
            {
                await userManager.CreateAsync(user,"Admin123#");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
            var userindbse = await userManager.FindByEmailAsync(user1.Email);
            if (userindbse == null)
            {
                await userManager.CreateAsync(user1,"Accountant123#");
                await userManager.AddToRoleAsync(user1, Roles.Accountant.ToString());
            }





        }
    }
}
