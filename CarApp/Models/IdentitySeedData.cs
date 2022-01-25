using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using CarApp.Enums;

namespace CarApp.Models
{
    public static class IdentitySeedData
    {
        private const string adminLogin = "admin2";
        private const string adminPassword = "Admin1!";

        private const string userLogin = "user2";
        private const string userPassword = "User1!";
        
        public static async void CreateUserRole(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));
            var userManager = (UserManager<IdentityUser>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<IdentityUser>));
            IdentityResult identityResult;

            foreach (var roleName in Enum.GetValues(typeof(Roles)))
            {
                var isRole = await roleManager.RoleExistsAsync(roleName.ToString());

                if (!isRole)
                {
                    identityResult = await roleManager.CreateAsync(new IdentityRole(roleName.ToString()));
                }
            }

            IdentityUser admin = await userManager.FindByIdAsync(adminLogin);
            if(admin == null)
            {
                admin = new IdentityUser()
                {
                    UserName = adminLogin,
                    Email = "admin@admin.pl",
                    PhoneNumber = "111111111"
                };
                await userManager.CreateAsync(admin, adminPassword);
            }
            await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());

            IdentityUser user = await userManager.FindByIdAsync(userLogin);
            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = userLogin,
                    Email = "user@user.pl",
                    PhoneNumber = "222222222"
                };
                await userManager.CreateAsync(user, userPassword);
            }
            await userManager.AddToRoleAsync(user, Roles.User.ToString());
        }
    }
}
