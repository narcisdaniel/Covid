using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DawApp.Models
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Parola1@#").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Moderator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Moderator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
